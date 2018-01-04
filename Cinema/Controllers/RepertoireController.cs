using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Context;
using Cinema.Models;

namespace Cinema.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RepertoireController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: Repertoire
        public ActionResult Index()
        {
            var moviePositions = db.MoviePositions.Include(m => m.Cinema).Include(m => m.Movie);
            return View(moviePositions.ToList());
        }

        public ActionResult Terms(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePosition moviePosition = db.MoviePositions.Find(id);
            if (moviePosition == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.PositionId = moviePosition.Id;
                ViewBag.MovieAndCinema = moviePosition.Cinema.FullName + " dla filmu " + moviePosition.Movie.Title;
                var listOfMovieTerms = db.MoviePositionsDates.Include(m => m.MoviePosition).Include(m => m.MovieType).Where(m => m.MoviePosition.Id == id);

                return View(listOfMovieTerms.ToList());
            }
        }

        // GET: Repertoire/Create
        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "Fullname");
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title");
            return View();
        }

        // POST: Repertoire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieId,CinemaId,MovieTitle,MovieDuration")] MoviePosition moviePosition)
        {
            if (ModelState.IsValid)
            {
                db.MoviePositions.Add(moviePosition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "City", moviePosition.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", moviePosition.MovieId);
            return View(moviePosition);
        }



        // POST: Repertoire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieId,CinemaId,MovieTitle,MovieDuration")] MoviePosition moviePosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviePosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "Id", "City", moviePosition.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", moviePosition.MovieId);
            return View(moviePosition);
        }

        // GET: Repertoire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePosition moviePosition = db.MoviePositions.Find(id);
            if (moviePosition == null)
            {
                return HttpNotFound();
            }

            var moviePositionsDates = db.MoviePositionsDates;
            foreach(var moviepositiondates in moviePositionsDates)
            {
                if(moviepositiondates.MoviePositionId == id)
                {
            db.MoviePositionsDates.Remove(moviepositiondates);
                    
                }
            }
            db.SaveChanges();
            return View(moviePosition);
        }

        // POST: Repertoire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoviePosition moviePosition = db.MoviePositions.Find(id);
            db.MoviePositions.Remove(moviePosition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListOfMovieTerms(int id)
        {
            var movieAndCinema = db.MoviePositionsDates.Include(m => m.MoviePosition).Include(m => m.MovieType).Where(m => m.MoviePosition.Id == id).FirstOrDefault();
          
            ViewBag.MovieAndCinema = movieAndCinema.MoviePosition.Cinema.FullName + " dla filmu " + movieAndCinema.MoviePosition.Movie.Title;
            var listOfMovieTerms = db.MoviePositionsDates.Include(m => m.MoviePosition).Include(m => m.MovieType).Where(m => m.MoviePosition.Id == id);
            return View(listOfMovieTerms.ToList());
        }

        public ActionResult EditTerm(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTerm([Bind(Include = "Id,MoviePositionId,MovieTypeId,DateTime")] MoviePositionDates moviePositionDates)
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
        public ActionResult DeleteTerm(int? id)
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

        [HttpPost, ActionName("DeleteTerm")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedTerm(int id)
        {
            MoviePositionDates moviePositionDates = db.MoviePositionsDates.Find(id);
            db.MoviePositionsDates.Remove(moviePositionDates);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateTerm(int id)
        {
            ViewBag.PositionId = id;
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
                moviePositionDates.MoviePositionId = 5;
                db.MoviePositionsDates.Add(moviePositionDates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MoviePositionId = new SelectList(db.MoviePositions, "Id", "MovieTitle", moviePositionDates.MoviePositionId);
            ViewBag.MovieTypeId = new SelectList(db.MovieTypes, "Id", "Name", moviePositionDates.MovieTypeId);
            return View(moviePositionDates);
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
