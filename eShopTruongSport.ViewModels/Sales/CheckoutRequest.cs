using System;
using System.Collections.Generic;

namespace eShopTruongSport.ViewModels.Sales
{
    public class CheckoutRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public Guid? userId { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderDetails { get; set; }
    }
}