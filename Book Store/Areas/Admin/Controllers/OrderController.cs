using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book_Store.Models;
using Book_Store.Areas.Admin.Models;

namespace Book_Store.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        // GET: /Admin/Order/
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.User);
            return View(orders.ToList());
        }

        // GET: /Admin/Order/Details/5
        public ActionResult Details(int? id)
        {

            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.OrderDetails = db.OrderDetails.Where(k => k.OrderId == id).ToList();
            orderViewModel.CustomerOrder = db.Orders.Find(id);
            orderViewModel.CustomerInfo = db.CustomerDetails.Where(k => k.OrderId == id).FirstOrDefault();

            foreach (var item in orderViewModel.OrderDetails)
            {
                item.SubTotal = item.Quantity * item.BookPrice;
            }

            decimal totalBookWeight = orderViewModel.CustomerOrder.TotalWeight;
            decimal subTotal = orderViewModel.OrderDetails.Sum(k => k.SubTotal);
            decimal totalShippingCharges = orderViewModel.CustomerOrder.TotalShippingCharges;

            ViewData["TotalWeight"] = totalBookWeight;
            ViewData["SubTotal"] = subTotal;
            ViewData["ShippingCharges"] = totalShippingCharges;
            ViewData["NetTotal"] = subTotal + totalShippingCharges;


            return View(orderViewModel);
        }

        // GET: /Admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: /Admin/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrderId,UserId,Createdate,Status,TotalWeight,TotalShippingCharges")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", order.UserId);
            return View(order);
        }

        // GET: /Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", order.UserId);
            return View(order);
        }

        // POST: /Admin/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrderId,UserId,Createdate,Status,TotalWeight,TotalShippingCharges")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", order.UserId);
            return View(order);
        }

        // GET: /Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
