using eShopTruongSport.ViewModels.Catalog.Categories;
using eShopTruongSport.ViewModels.Catalog.ProductImages;
using eShopTruongSport.ViewModels.Catalog.Products;
using eShopTruongSport.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopTruongSport.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductVm> GetById(int productId, string languageId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewcount(int productId);

        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);
    }
}