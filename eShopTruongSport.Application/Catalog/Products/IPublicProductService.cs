using eShopTruongSport.ViewModels.Catalog.Products;
using eShopTruongSport.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopTruongSport.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}