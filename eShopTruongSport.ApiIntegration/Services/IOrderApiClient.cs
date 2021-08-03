using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopTruongSport.ApiIntegration.Services
{
    public interface IOrderApiClient
    {
        Task<bool> CreateOrder(CheckoutRequest request);
        Task<PagedResult<OrderVm>> GetPagings(GetOrderPagingRequest request);
    }
}
