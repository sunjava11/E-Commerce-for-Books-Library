using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class BooksController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        //
        // GET: /Books/
        public ActionResult Index()
        {
            var booksList = db.Books.ToList();
            return View(booksList);
        }
	}
}