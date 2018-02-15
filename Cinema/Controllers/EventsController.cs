using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Context;
using Cinema.Models;

namespace Cinema.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }


        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,ImageFile")] Event @event)
        {
            if (ModelState.IsValid)
            {
                if (@event.ImageFile != null && @event.ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(@event.ImageFile.FileName);
                    string extension = Path.GetExtension(@event.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    @event.ImagePath = "~/Content/images/" + filename;
                    @event.ImageName = filename + extension;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    @event.ImageFile.SaveAs(filename);
                    db.Events.Add(@event);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,ImageFile")] Event @event)
        {
            if (ModelState.IsValid)
            {
                if (@event.ImageFile != null && @event.ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(@event.ImageFile.FileName);
                    string extension = Path.GetExtension(@event.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    @event.ImagePath = "~/Content/images/" + filename;
                    @event.ImageName = filename + extension;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    @event.ImageFile.SaveAs(filename);
                    db.Entry(@event).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
