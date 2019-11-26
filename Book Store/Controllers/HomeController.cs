using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class HomeController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.BookCategories = db.BookCategories.ToList();
            homeViewModel.AllCategoryBooks = new List<Book>();

            foreach (var item in homeViewModel.BookCategories)
            {
                List<Book> categoryBooks = db.Books.Where(k => k.BookCategoryId == item.Id).Take(4).ToList();
                homeViewModel.AllCategoryBooks.AddRange(categoryBooks);
            }

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}