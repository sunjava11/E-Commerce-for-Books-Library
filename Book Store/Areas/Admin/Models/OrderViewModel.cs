using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public Order CustomerOrder { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public CustomerDetail CustomerInfo { get; set; }
    }
}