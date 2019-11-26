using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book_Store.Models;
using System.IO;

namespace Book_Store.Areas.Admin.Controllers
{
    public class BooksController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        // GET: /Admin/Books/
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.BookCategory);
            return View(books.ToList());
        }

        // GET: /Admin/Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Admin/Books/Create
        public ActionResult Create()
        {
            ViewBag.BookCategoryId = new SelectList(db.BookCategories, "Id", "Categoryname");
            return View();
        }

        // POST: /Admin/Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Authorname,Price,Publishdate,BookCategoryId,BookImageUrl,Rating,Weight,Createdate")] Book book)
        {
            
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    file.SaveAs(path);

                    book.BookImageUrl = fileName;
                }

                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookCategoryId = new SelectList(db.BookCategories, "Id", "Categoryname", book.BookCategoryId);
            return View(book);
        }

        // GET: /Admin/Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookCategoryId = new SelectList(db.BookCategories, "Id", "Categoryname", book.BookCategoryId);
            return View(book);
        }

        // POST: /Admin/Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Authorname,Price,Publishdate,BookCategoryId,BookImageUrl,Rating,Weight,Createdate")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookCategoryId = new SelectList(db.BookCategories, "Id", "Categoryname", book.BookCategoryId);
            return View(book);
        }

        // GET: /Admin/Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
