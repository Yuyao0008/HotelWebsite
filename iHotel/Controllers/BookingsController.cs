using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FIT5032_Assign1_v6.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_Assign1_v6.Controllers
{
    public class BookingsController : Controller
    {
        private iHotel_Model1Container db = new iHotel_Model1Container();

        // GET: Bookings
        [Authorize]
        public ActionResult Index()
        {
         
            var userId = User.Identity.GetUserId();
                var bookings = db.BookingSet.Where(b => b.UserId == userId).ToList();
                return View(bookings);  
        }


        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.BookingSet.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.RoomInforId = new SelectList(db.RoomInforSet, "Id", "Type");
            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "FirstName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,From,To,Adult_Number,Children_Number,RoomInforId,CustomerId")] Booking booking)
        {
            booking.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(booking);
            if (ModelState.IsValid)
            {

                booking.From_date = DateTime.Now;
                booking.To_date = DateTime.Now.AddDays(1);

                db.BookingSet.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomInforId = new SelectList(db.RoomInforSet, "Id", "Type", booking.RoomInforId);
            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "FirstName", booking.CustomerId);
            return View(booking);
        }

     
        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.BookingSet.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomInforId = new SelectList(db.RoomInforSet, "Id", "Type", booking.RoomInforId);
            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "FirstName", booking.CustomerId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,From_date,To_date,Adult_Number,Children_Number,RoomInforId,CustomerId")] Booking booking)
        {
            booking.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(booking);
            if (ModelState.IsValid)

                if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomInforId = new SelectList(db.RoomInforSet, "Id", "Type", booking.RoomInforId);
            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "FirstName", booking.CustomerId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.BookingSet.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.BookingSet.Find(id);
            db.BookingSet.Remove(booking);
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
