using Book_Store.Helpers;
using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private UserHelper userHelper = new UserHelper();
        private bookStoreEntities db = new bookStoreEntities();

        [HttpGet]
        public ActionResult Login()
        {
            if (userHelper.IsUserLogin() == true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            Book_Store.Models.User matchedUser = db.Users.Where(k => k.Username == user.Username && k.Password == user.Password && k.IsAdmin == true).FirstOrDefault();

            if (matchedUser != null)
            {
                userHelper.SetLoginUser(matchedUser);

                return RedirectToAction("Index", "Dashboard");
            }


            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            userHelper.DestorySession();
            return RedirectToAction("Login", "Account");
        }
	}
}