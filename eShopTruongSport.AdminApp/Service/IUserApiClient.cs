using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopTruongSport.AdminApp.Service
{
   public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);
        Task<ApiResult<bool>> Delete(Guid id);
    }
}
