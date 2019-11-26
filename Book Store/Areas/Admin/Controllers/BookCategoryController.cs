using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book_Store.Models;

namespace Book_Store.Areas.Admin.Controllers
{
    public class BookCategoryController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        // GET: /Admin/BookCategory/
        public ActionResult Index()
        {
            return View(db.BookCategories.ToList());
        }

        // GET: /Admin/BookCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategory bookcategory = db.BookCategories.Find(id);
            if (bookcategory == null)
            {
                return HttpNotFound();
            }
            return View(bookcategory);
        }

        // GET: /Admin/BookCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/BookCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Categoryname,Createdate")] BookCategory bookcategory)
        {
            if (ModelState.IsValid)
            {
                db.BookCategories.Add(bookcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookcategory);
        }

        // GET: /Admin/BookCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategory bookcategory = db.BookCategories.Find(id);
            if (bookcategory == null)
            {
                return HttpNotFound();
            }
            return View(bookcategory);
        }

        // POST: /Admin/BookCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Categoryname,Createdate")] BookCategory bookcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookcategory);
        }

        // GET: /Admin/BookCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategory bookcategory = db.BookCategories.Find(id);
            if (bookcategory == null)
            {
                return HttpNotFound();
            }
            return View(bookcategory);
        }

        // POST: /Admin/BookCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCategory bookcategory = db.BookCategories.Find(id);
            db.BookCategories.Remove(bookcategory);
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
