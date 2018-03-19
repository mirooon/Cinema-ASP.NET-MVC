using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;
using Cinema.Context;
using Cinema.Context.Cinema.Context;

namespace Cinema.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviePositionDatesController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: MoviePositionDates
        public ActionResult Index()
        {
            var moviePositionDates = db.MoviePositionsDates.Include(m => m.MoviePosition).Include(m => m.MovieType);
            return View(moviePositionDates.ToList());
        }

        // GET: MoviePositionDates/Create
        public ActionResult CreateTerm()
        {
            ViewBag.MoviePositionId = new SelectList(db.MoviePositions, "Id", "MovieTitle");
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "Id", "Name");
            return View();
        }

        // POST: MoviePositionDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTerm([Bind(Include = "Id,MoviePositionId,MovieTypeId,DateTime")] MoviePositionDates moviePositionDates)
        {
            if (ModelState.IsValid)
            {
                db.MoviePositionsDates.Add(moviePositionDates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MoviePositionId = new SelectList(db.MoviePositions, "Id", "MovieTitle", moviePositionDates.MoviePositionId);
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "Id", "Name", moviePositionDates.MovieTypeId);
            return View(moviePositionDates);
        }

        // GET: MoviePositionDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePositionDates moviePositionDates = db.MoviePositionsDates.Find(id);
            if (moviePositionDates == null)
            {
                return HttpNotFound();
            }
            ViewBag.MoviePositionId = new SelectList(db.MoviePositions, "Id", "MovieTitle", moviePositionDates.MoviePositionId);
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "Id", "Name", moviePositionDates.MovieTypeId);
            return View(moviePositionDates);
        }

        // POST: MoviePositionDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MoviePositionId,MovieTypeId,DateTime")] MoviePositionDates moviePositionDates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviePositionDates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MoviePositionId = new SelectList(db.MoviePositions, "Id", "MovieTitle", moviePositionDates.MoviePositionId);
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "Id", "Name", moviePositionDates.MovieTypeId);
            return View(moviePositionDates);
        }

        // GET: MoviePositionDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePositionDates moviePositionDates = db.MoviePositionsDates.Find(id);
            if (moviePositionDates == null)
            {
                return HttpNotFound();
            }
            return View(moviePositionDates);
        }

        // POST: MoviePositionDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoviePositionDates moviePositionDates = db.MoviePositionsDates.Find(id);
            db.MoviePositionsDates.Remove(moviePositionDates);
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
