using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}