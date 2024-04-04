using KhachSan.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using HotelManagmentSystem.Factory.AbstractFactor;
//using HotelManagmentSystem.Factory.AbstractFactory;

namespace HotelManagmentSystem.Controllers
{
    public class tbl_roomController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: tbl_room
        public ActionResult Index()
        {
            var tbl_room = db.tbl_room.Include(t => t.tbl_booking_status).Include(t => t.tbl_room_type);
            return View(tbl_room.ToList());
        }

        // GET: tbl_room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_room tbl_room = db.tbl_room.Find(id);
            if (tbl_room == null)
            {
                return HttpNotFound();
            }
            return View(tbl_room);
        }

        // GET: tbl_room/Create
        public ActionResult Create()
        {
            ViewBag.booking_status_id = new SelectList(db.tbl_booking_status, "booking_status_id", "booking_status");
            ViewBag.room_type_id = new SelectList(db.tbl_room_type, "room_type_id", "room_name");
            return View();
        }

        // POST: tbl_room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "room_id,room_number,room_type_id,booking_status_id,is_Active")] tbl_room tbl_room)
        {
            if (ModelState.IsValid)
            {
                //IRoomFactory factory = new RoomSystemFactory().Create(tbl_room);
                //Room room = new Room(factory);
                //tbl_room.room_number = room.GetRoom(); ;

                db.tbl_room.Add(tbl_room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.booking_status_id = new SelectList(db.tbl_booking_status, "booking_status_id", "booking_status", tbl_room.booking_status_id);
            ViewBag.room_type_id = new SelectList(db.tbl_room_type, "room_type_id", "room_name", tbl_room.room_type_id);
            return View(tbl_room);
        }

        // GET: tbl_room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_room tbl_room = db.tbl_room.Find(id);
            if (tbl_room == null)
            {
                return HttpNotFound();
            }
            ViewBag.booking_status_id = new SelectList(db.tbl_booking_status, "booking_status_id", "booking_status", tbl_room.booking_status_id);
            ViewBag.room_type_id = new SelectList(db.tbl_room_type, "room_type_id", "room_name", tbl_room.room_type_id);
            return View(tbl_room);
        }

        // POST: tbl_room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "room_id,room_number,room_type_id,booking_status_id,is_Active")] tbl_room tbl_room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.booking_status_id = new SelectList(db.tbl_booking_status, "booking_status_id", "booking_status", tbl_room.booking_status_id);
            ViewBag.room_type_id = new SelectList(db.tbl_room_type, "room_type_id", "room_name", tbl_room.room_type_id);
            return View(tbl_room);
        }

        // GET: tbl_room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_room tbl_room = db.tbl_room.Find(id);
            if (tbl_room == null)
            {
                return HttpNotFound();
            }
            return View(tbl_room);
        }

        // POST: tbl_room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_room tbl_room = db.tbl_room.Find(id);
            db.tbl_room.Remove(tbl_room);
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
