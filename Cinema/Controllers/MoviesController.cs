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
    public class MoviesController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.AgeRestriction).Include(m => m.Genre);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.AgeRestrictionId = new SelectList(db.AgesRestriction, "Id", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,OryginalTitle,Cast,Director,Production,Premiere,Duration,Description,TrailerLinkYoutube,ImagePath,AgeRestrictionId,Status,GenreId,ImageFile")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.ImageFile != null && movie.ImageFile.ContentLength > 0)
                {
                    int cos = movie.ImageFile.ContentLength;
                string filename = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
                    string extension = Path.GetExtension(movie.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    movie.ImagePath = "~/Content/images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    movie.ImageFile.SaveAs(filename);
                db.Movies.Add(movie);
                db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.AgeRestrictionId = new SelectList(db.AgesRestriction, "Id", "Name", movie.AgeRestrictionId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgeRestrictionId = new SelectList(db.AgesRestriction, "Id", "Name", movie.AgeRestrictionId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,OryginalTitle,Cast,Director,Production,Premiere,Duration,Description,TrailerLinkYoutube,ImagePath,AgeRestrictionId,Status,GenreId,ImageFile")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.ImageFile != null && movie.ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
                    string extension = Path.GetExtension(movie.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    movie.ImagePath = "~/Content/images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    movie.ImageFile.SaveAs(filename);
                    db.Entry(movie).State = EntityState.Modified;
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            ViewBag.AgeRestrictionId = new SelectList(db.AgesRestriction, "Id", "Name", movie.AgeRestrictionId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            System.IO.File.Delete(Path.Combine(Server.MapPath(movie.ImagePath)));
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
