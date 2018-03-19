using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Context;
using Cinema.Context.Cinema.Context;
using Cinema.CustomAttributes;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class CinemaPlacesController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: CinemaPlaces
        public ActionResult Index()
        {
            return View(db.Cinemas.ToList());
        }

        // GET: CinemaPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaPlace cinemaPlace = db.Cinemas.Find(id);
            if (cinemaPlace == null)
            {
                return HttpNotFound();
            }
            return View(cinemaPlace);
        }

        // GET: CinemaPlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,City,Name,Street,Number,PostCode,Longitude,Latitude,ImagePath")] CinemaPlace cinemaPlace)
        {
            if (ModelState.IsValid)
            {
                db.Cinemas.Add(cinemaPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinemaPlace);
        }

        // GET: CinemaPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaPlace cinemaPlace = db.Cinemas.Find(id);
            if (cinemaPlace == null)
            {
                return HttpNotFound();
            }
            return View(cinemaPlace);
        }

        // POST: CinemaPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,City,Name,Street,Number,PostCode,Longitude,Latitude,ImagePath")] CinemaPlace cinemaPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinemaPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinemaPlace);
        }

        // GET: CinemaPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CinemaPlace cinemaPlace = db.Cinemas.Find(id);
            if (cinemaPlace == null)
            {
                return HttpNotFound();
            }
            return View(cinemaPlace);
        }

        // POST: CinemaPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CinemaPlace cinemaPlace = db.Cinemas.Find(id);
            db.Cinemas.Remove(cinemaPlace);
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
        [AjaxChildActionOnly]
        public JsonResult CinemasForGoogleMarks()
        {
            var cinemas = db.Cinemas.ToList();

            return Json(cinemas, JsonRequestBehavior.AllowGet);
        }
    }
}
