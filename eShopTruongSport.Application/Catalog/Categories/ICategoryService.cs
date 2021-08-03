using eShopTruongSport.ViewModels.Catalog.Categories;
using eShopTruongSport.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopTruongSport.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<int> Delete(int categoryId);
        Task<PagedResult<CategoryVm>> GetAllPaging(GetCategoryRequest request);
        Task<List<CategoryVm>> GetAll(string languageId);
        Task<int> CreateCategory(CategoryCreateRequest request);
        Task<CategoryVm> GetById(string languageId, int id);
    }
}
