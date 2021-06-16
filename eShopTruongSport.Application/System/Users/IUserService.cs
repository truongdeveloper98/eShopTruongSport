﻿using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopTruongSport.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
        Task<PagedResult<UserVm>> GetListUser(GetUserPagingRequest request);
    }
}