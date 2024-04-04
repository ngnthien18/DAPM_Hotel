using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models.DB;

namespace KhachSan.Controllers
{
    public class tbl_customerController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: tbl_customer
        public ActionResult Index()
        {
            return View(db.tbl_customer.ToList());
        }

        // GET: tbl_customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            if (tbl_customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer);
        }

        // GET: tbl_customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cus_id,cusname,emailcus,cus_password")] tbl_customer tbl_customer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_customer.Add(tbl_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_customer);
        }

        // GET: tbl_customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            if (tbl_customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer);
        }

        // POST: tbl_customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cus_id,cusname,emailcus,cus_password")] tbl_customer tbl_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_customer);
        }

        // GET: tbl_customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            if (tbl_customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customer);
        }

        // POST: tbl_customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_customer tbl_customer = db.tbl_customer.Find(id);
            db.tbl_customer.Remove(tbl_customer);
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
