using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Models
{
    public class HomeViewModel
    {
        public List<BookCategory> BookCategories { get; set; }
        public List<Book> AllCategoryBooks { get; set; }
    }
}