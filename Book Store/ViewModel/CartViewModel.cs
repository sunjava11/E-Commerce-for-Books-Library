using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.ViewModel
{
    public class CartViewModel
    {
        public int BookId { get; set; }
        public string BookImageUrl { get; set; }
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public decimal BookWeight { get; set; }
        public int BookQuantity { get; set; }
        public decimal SubTotal { get; set; }

    }
}