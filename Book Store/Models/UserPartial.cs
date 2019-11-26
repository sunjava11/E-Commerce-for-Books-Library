using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Store.Models
{

   [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        
    }

    public class UserMetaData
    {
        [Required]
        [Display(Name="User Name")]
        public string Username;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password;

    }
}