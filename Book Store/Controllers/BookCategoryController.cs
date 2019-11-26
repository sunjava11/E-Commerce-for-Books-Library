using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class BookCategoryController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        public ActionResult ViewCategory(int catId=1)
        {
            var booksList = db.Books.Where(k => k.BookCategoryId==catId).ToList();
            ViewBag.CategoryName = db.BookCategories.Where(k => k.Id==catId).Select(k => k.Categoryname).FirstOrDefault();
            ViewBag.CatId = catId;
            return View(booksList);
        }
	}
}