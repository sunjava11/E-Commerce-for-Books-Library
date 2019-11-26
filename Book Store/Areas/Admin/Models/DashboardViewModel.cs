using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int TotalOrders { get; set; }
        public decimal TotalSales { get; set; }
        public string MostOrderdBook { get; set; }
    }
}