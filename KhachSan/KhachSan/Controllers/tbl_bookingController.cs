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
    public class tbl_bookingController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: tbl_booking
        public ActionResult Index()
        {
            var tbl_booking = db.tbl_booking.Include(t => t.tbl_room).Include(t => t.tbl_payment_type);
            return View(tbl_booking.ToList());
        }
        public ActionResult CusIndex(int id)
        {
            return View(db.tbl_booking.Where(o => o.cus_id == id).ToList());
        }
        // GET: tbl_booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            if (tbl_booking == null)
            {
                return HttpNotFound();
            }
            return View(tbl_booking);
        }

        // GET: tbl_booking/Create
        public ActionResult Create()
        {
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number");
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type");
            return View();
        }

        // POST: tbl_booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_id,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount,cus_id")] tbl_booking tbl_booking)
        {
            if (ModelState.IsValid)
            {
                db.tbl_booking.Add(tbl_booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }

        // GET: tbl_booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            if (tbl_booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }

        // POST: tbl_booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount,cus_id")] tbl_booking tbl_booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }

        // GET: tbl_booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            if (tbl_booking == null)
            {
                return HttpNotFound();
            }
            return View(tbl_booking);
        }

        // POST: tbl_booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            db.tbl_booking.Remove(tbl_booking);
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
