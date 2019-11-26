using Book_Store.Areas.Admin.Models;
using Book_Store.Helpers;
using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private UserHelper userHelper = new UserHelper();
        private bookStoreEntities db = new bookStoreEntities();

        //
        // GET: /Admin/Dashboard/
        public ActionResult Index()
        {
            if(userHelper.IsUserLogin()==false)
            {
                return RedirectToAction("Login", "Account");
            }

            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            dashboardViewModel.TotalSales = 300;
            dashboardViewModel.MostOrderdBook = "Life Book";
            dashboardViewModel.TotalOrders = db.Orders.Count();


            return View(dashboardViewModel);
        }
	}
}