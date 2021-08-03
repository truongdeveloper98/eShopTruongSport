using eShopTruongSport.ViewModels.Catalog.Categories;
using eShopTruongSport.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopTruongSport.ApiIntegration.Services
{
    public interface ICategoryApiClient
    {
        Task<CategoryVm> GetById(string languageId, int id);
        Task<bool> CreateCategory(CategoryCreateRequest request);
        Task<bool> DeleteCategory(int categoryId);
        Task<List<CategoryVm>> GetAll(string languageId);
        Task<PagedResult<CategoryVm>> GetPagings(GetCategoryRequest request);
    }
}
