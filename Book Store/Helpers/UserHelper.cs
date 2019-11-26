using Book_Store.Models;
using Book_Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Helpers
{
    public class UserHelper
    {
        public int GetLoginUserId()
        {
            UserViewModel userViewModel = (UserViewModel)System.Web.HttpContext.Current.Session["UserLogin"];
            return userViewModel.UserId;
        }

        public string GetLoginUsername()
        {
            UserViewModel userViewModel = (UserViewModel)System.Web.HttpContext.Current.Session["UserLogin"];
            return userViewModel.UserName;
        }

        public void SetLoginUser(User matchedUser)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UserId = matchedUser.Id;
            userViewModel.IsAdmin = matchedUser.IsAdmin;
            userViewModel.UserName = matchedUser.Username;

            System.Web.HttpContext.Current.Session["UserLogin"] = userViewModel;
        }

        public void DestorySession()
        {
            System.Web.HttpContext.Current.Session["UserLogin"] = null;
        }


        public bool IsUserLogin()
        {
            if(System.Web.HttpContext.Current.Session["UserLogin"] !=null)
            {
                return true;
            }
            return false;
        }
    }
}