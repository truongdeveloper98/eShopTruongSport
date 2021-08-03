using eShopTruongSport.ApiIntegration.Services;
using eShopTruongSport.ViewModels.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopTruongSport.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        public OrderController(IOrderApiClient productApiClient,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

       
       
    }
}
