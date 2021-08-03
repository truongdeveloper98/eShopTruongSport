using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTruongSport.ViewModels.Sales
{
    public class OrderVm
    {
        public int OrderId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal totalMoney { get; set; }
        public string Name { get; set; }
    }
}
