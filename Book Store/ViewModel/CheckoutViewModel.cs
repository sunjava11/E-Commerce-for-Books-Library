using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.ViewModel
{
    public class CheckoutViewModel
    {
        public List<CartViewModel> CartItemsModel { get; set; }
        public string CustomerName { get; set; }

        public string PhoneNo { get; set; }

        public string ShippingAddress { get; set; }
    }
}