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
    public class ShippingChargeController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();

        // GET: /Admin/ShippingCharge/
        public ActionResult Index()
        {
            return View(db.ShippingCharges.ToList());
        }

        // GET: /Admin/ShippingCharge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCharge shippingcharge = db.ShippingCharges.Find(id);
            if (shippingcharge == null)
            {
                return HttpNotFound();
            }
            return View(shippingcharge);
        }

        // GET: /Admin/ShippingCharge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/ShippingCharge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ShippingRate,Weight,Createdate,id")] ShippingCharge shippingcharge)
        {
            if (ModelState.IsValid)
            {
                db.ShippingCharges.Add(shippingcharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shippingcharge);
        }

        // GET: /Admin/ShippingCharge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCharge shippingcharge = db.ShippingCharges.Find(id);
            if (shippingcharge == null)
            {
                return HttpNotFound();
            }
            return View(shippingcharge);
        }

        // POST: /Admin/ShippingCharge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ShippingRate,Weight,Createdate,id")] ShippingCharge shippingcharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingcharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shippingcharge);
        }

        // GET: /Admin/ShippingCharge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingCharge shippingcharge = db.ShippingCharges.Find(id);
            if (shippingcharge == null)
            {
                return HttpNotFound();
            }
            return View(shippingcharge);
        }

        // POST: /Admin/ShippingCharge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingCharge shippingcharge = db.ShippingCharges.Find(id);
            db.ShippingCharges.Remove(shippingcharge);
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
