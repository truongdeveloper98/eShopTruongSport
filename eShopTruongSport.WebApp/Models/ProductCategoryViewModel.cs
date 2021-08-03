using eShopTruongSport.ViewModels.Catalog.Categories;
using eShopTruongSport.ViewModels.Catalog.Products;
using eShopTruongSport.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopTruongSport.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVm> Products { get; set; }
    }
}