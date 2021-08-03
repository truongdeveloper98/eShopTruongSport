using eShopTruongSport.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTruongSport.ViewModels.Sales
{
   public class GetOrderPagingRequest : PagingRequestBase
    {
      public string Keyword { get; set; }
    }
}
