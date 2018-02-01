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
    public class BannersController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: Banners
        public ActionResult Index()
        {
            return View(db.Banners.ToList());
        }

        // GET: Banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImagePath,ImageName,ImageFile")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                if (banner.ImageFile != null && banner.ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(banner.ImageFile.FileName);
                    string extension = Path.GetExtension(banner.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    banner.ImagePath = "~/Content/images/" + filename;
                    banner.ImageName = filename + extension;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    banner.ImageFile.SaveAs(filename);
                    db.Banners.Add(banner);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        // GET: Banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImagePath,,ImageName,ImageFile")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                if (banner.ImageFile != null && banner.ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(banner.ImageFile.FileName);
                    string extension = Path.GetExtension(banner.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    banner.ImagePath = "~/Content/images/" + filename;
                    banner.ImageName = filename + extension;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    banner.ImageFile.SaveAs(filename);
                    db.Entry(banner).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(banner);
        }

        // GET: Banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = db.Banners.Find(id);
            db.Banners.Remove(banner);
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
