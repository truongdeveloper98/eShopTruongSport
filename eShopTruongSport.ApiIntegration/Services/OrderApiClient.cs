using eShopTruongSport.Utilities.Constants;
using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopTruongSport.ApiIntegration.Services
{
    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public OrderApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateOrder(CheckoutRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

           
            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Email) ? "" : request.Email.ToString()), "email");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PhoneNumber) ? "" : request.PhoneNumber.ToString()), "phoneNumber");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Address) ? "" : request.Address.ToString()), "address");
            requestContent.Add(new StringContent(request.userId.ToString()), "userId");
            requestContent.Add(new StringContent(request.OrderDetails), "orderDetails");

            var response = await client.PostAsync($"/api/Orders/", requestContent);
            return response.IsSuccessStatusCode;
        }
            public async Task<PagedResult<OrderVm>> GetPagings(GetOrderPagingRequest request)
            {
                var data = await GetAsync<PagedResult<OrderVm>>(
                    $"/api/orders/paging?pageIndex={request.PageIndex}" +
                    $"&pageSize={request.PageSize}" +
                    $"&keyword={request.Keyword}");
                return data;
            }
    }
 }
