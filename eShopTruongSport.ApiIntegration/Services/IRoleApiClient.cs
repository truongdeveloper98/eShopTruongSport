using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopTruongSport.ApiIntegration.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
        Task<ApiResult<bool>> CreateRole(CreateRoleRequest request);
        Task<ApiResult<PagedResult<RoleVm>>> GetUsersPagings(GetRoleRequest request);
    }
}
