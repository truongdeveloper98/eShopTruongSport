using eShopTruongSport.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTruongSport.ViewModels.Catalog.Categories
{
    public class GetCategoryRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
    }
}
