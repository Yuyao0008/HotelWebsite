using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assign1_v6.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_Assign1_v6.Controllers
{
    public class RoomInforsController : Controller
    {
        private iHotel_Model1Container db = new iHotel_Model1Container();

        // GET: RoomInfors
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var rooms = db.RoomInforSet.Where(r => r.UserId == userId).ToList();


            return View(rooms);

        }

        // GET: RoomInfors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInfor roomInfor = db.RoomInforSet.Find(id);
            if (roomInfor == null)
            {
                return HttpNotFound();
            }
            return View(roomInfor);
        }

        // GET: RoomInfors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomInfors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Type,Description")] RoomInfor roomInfor)
        {
            roomInfor.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(roomInfor);

            if (ModelState.IsValid)
            {
                db.RoomInforSet.Add(roomInfor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomInfor);
        }

        // GET: RoomInfors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInfor roomInfor = db.RoomInforSet.Find(id);
            if (roomInfor == null)
            {
                return HttpNotFound();
            }
            return View(roomInfor);
        }

        // POST: RoomInfors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Type,Description")] RoomInfor roomInfor)
        {
            roomInfor.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(roomInfor);
            if (ModelState.IsValid)
            {
                db.Entry(roomInfor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomInfor);
        }

        // GET: RoomInfors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInfor roomInfor = db.RoomInforSet.Find(id);
            if (roomInfor == null)
            {
                return HttpNotFound();
            }
            return View(roomInfor);
        }

        // POST: RoomInfors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomInfor roomInfor = db.RoomInforSet.Find(id);
            db.RoomInforSet.Remove(roomInfor);
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
