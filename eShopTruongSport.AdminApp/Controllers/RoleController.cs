using eShopTruongSport.ApiIntegration.Services;
using eShopTruongSport.ViewModels.System.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace eShopTruongSport.AdminApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;
        public RoleController(IConfiguration configuration, IRoleApiClient roleApiClient)
        {
            _roleApiClient = roleApiClient;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> Create(CreateRoleRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _roleApiClient.CreateRole(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới quyền thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm quyền thất bại");
            return View(request);
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetRoleRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _roleApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ObjResult);
        }
    }
}
