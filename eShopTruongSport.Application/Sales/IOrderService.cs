using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.Sales;
using System.Threading.Tasks;

namespace eShopTruongSport.Application.Sales
{
    public interface IOrderService
    {
        Task<int> CreateOrder(CheckoutRequest request);
        Task<PagedResult<OrderVm>> GetAllPaging(GetOrderPagingRequest request);
    }
}
