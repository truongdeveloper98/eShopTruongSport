using eShopTruongSport.Data.EF;
using eShopTruongSport.Data.Entities;
using eShopTruongSport.ViewModels.Common;
using eShopTruongSport.ViewModels.Sales;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eShopTruongSport.Application.Sales
{
    public class OrderService : IOrderService
    {
        private readonly EShopDbContext _context;
        public OrderService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(CheckoutRequest request)
        {
            var orders = JsonConvert.DeserializeObject <List<OrderDetailVm>>(request.OrderDetails);
            var orderDetails = new List<OrderDetail>();
            foreach (var  item in orders)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                orderDetails.Add(new OrderDetail()
                {
                   ProductId = item.ProductId,
                   Quantity = item.Quantity,
                   Price = product.Price * item.Quantity
                });
            }
            var order = new Order()
            {
                ShipName = request.Name,
                ShipAddress = request.Address,
                ShipEmail = request.Email,
                ShipPhoneNumber = request.PhoneNumber,
                OrderDate = DateTime.Now,
                UserId  = request.userId,
                OrderDetails = orderDetails
            };
            _context.Orders.Add(order);
            return await _context.SaveChangesAsync();

        }

        public async Task<PagedResult<OrderVm>> GetAllPaging(GetOrderPagingRequest request)
        {
            var query = from o in _context.Orders
                        join od in _context.OrderDetails on o.Id equals od.OrderId 
                        where o.Id == od.OrderId
                        group new { o, od } by new { o.Id, o.ShipName, o.OrderDate} into order
                        select new {
                            order = order.Key,
                            Name = order.Key.ShipName,
                            OrderDate = order.Key.OrderDate,
                            Id = order.Key.Id,
                            totalMoney = order.Sum(x=>x.od.Price)
                        };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.order.ShipName.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
               
                .Select(x => new OrderVm()
                {
                    OrderId = x.order.Id,
                    Name = x.order.ShipName,
                    DateCreated = x.order.OrderDate,
                    totalMoney = x.totalMoney
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<OrderVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
