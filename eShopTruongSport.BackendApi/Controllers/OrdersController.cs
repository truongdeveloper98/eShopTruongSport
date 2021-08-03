using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopTruongSport.Application.Sales;
using eShopTruongSport.ViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopTruongSport.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService productService)
        {
            _orderService = productService;
        }
        [HttpGet("paging")]
        [Authorize]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetOrderPagingRequest request)
        {
            var products = await _orderService.GetAllPaging(request);
            return Ok(products);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CheckoutRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _orderService.CreateOrder(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
