using Cinema.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class MovieDetailsController : Controller
    {
        // GET: MovieDetails
        public ActionResult Index()
        {
            

            return View();
        }
        public ActionResult ShowMovieDetails(int id)
        {
            CinemaDbContext db = new CinemaDbContext();

            var vm = db.Movies.Include("Genre").Include("AgeRestriction").Where(a => a.Id == id).FirstOrDefault();
            return View(vm);
        }
    }
}