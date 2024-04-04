using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models.DB;
using System.Xml.Linq;
using System.Linq;

namespace HotelManagmentSystem.Controllers
{
    public class tbl_booking_statusController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: tbl_booking_status
        public ActionResult Index()
        {
            return View(db.tbl_booking_status.ToList());
        }

        // GET: tbl_booking_status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            if (tbl_booking_status == null)
            {
                return HttpNotFound();
            }
            return View(tbl_booking_status);
        }

        // GET: tbl_booking_status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_booking_status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_status_id,booking_status")] tbl_booking_status tbl_booking_status)
        {
            if (ModelState.IsValid)
            {
                db.tbl_booking_status.Add(tbl_booking_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_booking_status);
        }

        // GET: tbl_booking_status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            if (tbl_booking_status == null)
            {
                return HttpNotFound();
            }
            return View(tbl_booking_status);
        }

        // POST: tbl_booking_status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_status_id,booking_status")] tbl_booking_status tbl_booking_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_booking_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_booking_status);
        }

        // GET: tbl_booking_status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            if (tbl_booking_status == null)
            {
                return HttpNotFound();
            }
            return View(tbl_booking_status);
        }

        // POST: tbl_booking_status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            db.tbl_booking_status.Remove(tbl_booking_status);
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
