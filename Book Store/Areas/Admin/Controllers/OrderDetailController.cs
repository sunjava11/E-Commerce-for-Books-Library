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
    public class OrderDetailController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        // GET: /Admin/OrderDetail/
        public ActionResult Index()
        {
            var orderdetails = db.OrderDetails.Include(o => o.Order);
            return View(orderdetails.ToList());
        }

        // GET: /Admin/OrderDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        // GET: /Admin/OrderDetail/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Status");
            return View();
        }

        // POST: /Admin/OrderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,BookId,Quantity,BookPrice,BookWeight,Createdate,OrderId")] OrderDetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Status", orderdetail.OrderId);
            return View(orderdetail);
        }

        // GET: /Admin/OrderDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Status", orderdetail.OrderId);
            return View(orderdetail);
        }

        // POST: /Admin/OrderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,BookId,Quantity,BookPrice,BookWeight,Createdate,OrderId")] OrderDetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Status", orderdetail.OrderId);
            return View(orderdetail);
        }

        // GET: /Admin/OrderDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
        }

        // POST: /Admin/OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderdetail = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderdetail);
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
