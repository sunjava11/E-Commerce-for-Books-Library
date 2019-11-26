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
    
    public partial class Book
    {
        public Book()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Authorname { get; set; }
        public decimal Price { get; set; }
        public System.DateTime Publishdate { get; set; }
        public int BookCategoryId { get; set; }
        public string BookImageUrl { get; set; }
        public Nullable<int> Rating { get; set; }
        public decimal Weight { get; set; }
        public System.DateTime Createdate { get; set; }
    
        public virtual BookCategory BookCategory { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
