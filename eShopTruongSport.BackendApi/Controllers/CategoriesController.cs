using eShopTruongSport.Application.Catalog.Categories;
using eShopTruongSport.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopTruongSport.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCategoryRequest request)
        {
            var products = await _categoryService.GetAllPaging(request);
            return Ok(products);
        }
        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result = await _categoryService.Delete(categoryId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _categoryService.GetAll(languageId);
            return Ok(products);
        }
        [HttpGet("{id}/{languageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
            var category = await _categoryService.GetById(languageId, id);
            return Ok(category);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _categoryService.CreateCategory(request);
            if (categoryId == 0)
                return BadRequest();

            var product = await _categoryService.GetById(request.LanguageId, categoryId);

            return CreatedAtAction(nameof(GetById), new { id = categoryId }, product);
        }
    }
}
