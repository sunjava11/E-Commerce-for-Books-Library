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
    
    public partial class BookCategory
    {
        public BookCategory()
        {
            this.Books = new HashSet<Book>();
        }
    
        public int Id { get; set; }
        public string Categoryname { get; set; }
        public System.DateTime Createdate { get; set; }
    
        public virtual ICollection<Book> Books { get; set; }
    }
}