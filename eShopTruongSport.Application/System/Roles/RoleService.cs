using eShopTruongSport.Data.Entities;
using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.System.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopTruongSport.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public RoleService(RoleManager<AppRole> roleManager,  IConfiguration config)
        {
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<bool>> Create(CreateRoleRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.Name);
            if (role != null)
            {
                return new ApiErrorResult<bool>("Quyền đã tồn tại");
            }
            role = new AppRole()
            {
                Name = request.Name,
                Description = request.Description
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Tạo mới không thành công");
        }

        public async Task<List<RoleVm>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();

            return roles;
        }

        public async Task<ApiResult<PagedResult<RoleVm>>> GetRolesPaging(GetRoleRequest request)
        {
            var query = _roleManager.Roles;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new RoleVm()
                {
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<RoleVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<RoleVm>>(pagedResult);
        }
    }
}
