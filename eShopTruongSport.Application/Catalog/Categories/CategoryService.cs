using eShopTruongSport.Data.EF;
using eShopTruongSport.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.Data.Entities;
using eShopTruongSport.Utilities.Exceptions;

namespace eShopTruongSport.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _context;

        public CategoryService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCategory(CategoryCreateRequest request)
        {
            var category = new Category()
            {
                IsShowOnHome = true,
                SortOrder = request.SortOrder,
                ParentId = request.parentId,
                CategoryTranslations = new List<CategoryTranslation>()
                {
                    new CategoryTranslation()
                    {
                        LanguageId = request.LanguageId,
                        Name = request.Name,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        SeoDescription = request.SeoDescription
                    }
                }
                
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> Delete(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null) throw new EShopException($"Cannot find a product: {categoryId}");
            var categoryTranslation = _context.CategoryTranslations.Where(x => x.CategoryId == categoryId);
            foreach (var tran in categoryTranslation)
            {
                _context.CategoryTranslations.Remove(tran);
            }
            var childCa =  _context.Categories.Where(x => x.ParentId == categoryId);
            foreach(var ca in childCa)
            {
                _context.Categories.Remove(ca);
            }
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                 ParentId = x.c.ParentId
            }).ToListAsync();
        }

        public async Task<PagedResult<CategoryVm>> GetAllPaging(GetCategoryRequest request)
        {
            var query =from c in _context.Categories
                       join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == request.LanguageId
                        select new { c,ct};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.ct.Name.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryVm()
                {
                    Id = x.c.Id,
                    Name = x.ct.Name
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<CategoryVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();
        }
    }
}
