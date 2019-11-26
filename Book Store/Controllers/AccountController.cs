using Book_Store.Helpers;
using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class AccountController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();
        private UserHelper userHelper = new UserHelper();

        [HttpGet]
        public ActionResult Login()
        {
            if(userHelper.IsUserLogin()==true)
            {
               return RedirectToAction("Index", "Books");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            
            Book_Store.Models.User matchedUser = db.Users.Where(k => k.Username==user.Username && k.Password==user.Password && k.IsAdmin==false).FirstOrDefault();

            if (matchedUser != null)
            {
                userHelper.SetLoginUser(matchedUser);

                if (TempData["actionName"] != null && TempData["controllername"] != null && TempData["catId"] != null && ((int)TempData["catId"])!=0)
                {
                    return RedirectToAction(TempData["actionName"].ToString(), TempData["controllerName"].ToString(), new { catId = (int)TempData["catId"] });
                }

                else if(TempData["actionName"]!=null && TempData["controllername"]!=null)
                {
                    return RedirectToAction(TempData["actionName"].ToString(), TempData["controllerName"].ToString());
                }

                return RedirectToAction("Index", "Books");
            }
            

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            userHelper.DestorySession();
            return RedirectToAction("Login","Account");
        }


        [HttpGet]
        public ActionResult Register()
        {
            if (userHelper.IsUserLogin() == true)
            {
               return RedirectToAction("Index", "Books");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            Book_Store.Models.User newUser = user;
            newUser.Createdate = DateTime.Now;
            newUser.IsAdmin = false;

            db.Users.Add(newUser);
            db.SaveChanges();

            AlertMessage.DisplayAlert("Registered Successfully", false);

            return View();
        }
	}
}