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
using System.IO;

namespace Cinema.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }


        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,ImageFile")] News news)
        {
            if (ModelState.IsValid)
            {
                if (news.ImageFile != null && news.ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                    string extension = Path.GetExtension(news.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    news.ImagePath = "~/Content/images/" + filename;
                    news.ImageName = filename + extension;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    news.ImageFile.SaveAs(filename);
                    db.Entry(news).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,ImageFile")] News news)
        {
            if (ModelState.IsValid)
            {
                if (news.ImageFile != null && news.ImageFile.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                    string extension = Path.GetExtension(news.ImageFile.FileName);
                    Guid filenameNumbers = new Guid();
                    filename = filename + filenameNumbers + extension;
                    news.ImagePath = "~/Content/images/" + filename;
                    news.ImageName = filename + extension;
                    filename = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    news.ImageFile.SaveAs(filename);
                    db.Entry(news).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
