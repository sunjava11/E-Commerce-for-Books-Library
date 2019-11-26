//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Book_Store.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.CustomerDetails = new HashSet<CustomerDetail>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public System.DateTime Createdate { get; set; }
        public string Status { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal TotalShippingCharges { get; set; }
    
        public virtual ICollection<CustomerDetail> CustomerDetails { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
