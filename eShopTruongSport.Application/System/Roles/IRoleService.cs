using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.System.Roles;
using eShopTruongSport.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopTruongSport.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
        Task<ApiResult<bool>> Create(CreateRoleRequest request);
        Task<ApiResult<PagedResult<RoleVm>>> GetRolesPaging(GetRoleRequest request);
    }
}
