using eShopTruongSport.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTruongSport.ViewModels.System.Roles
{
    public  class GetRoleRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
