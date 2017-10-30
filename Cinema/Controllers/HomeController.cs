using Cinema.Context;
using Cinema.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        CinemaDbContext db = new CinemaDbContext();

        public ActionResult Index()
        {
            //var cinemas = db.Cinemas.ToList();
            //SelectList listcinemas = new SelectList(cinemas, "Id", "FullName");
            //ViewBag.cinemaslist = listcinemas;

            ViewBag.CinemasList = new SelectList(db.Cinemas,"Id", "FullName");
            ViewBag.MoviesList = new SelectList(db.Movies, "Id", "Title");
            ViewBag.TypesList = new SelectList(db.MovieTypes, "Id", "Name");

            //var movies = db.Movies.ToList();
            //SelectList listmovies = new SelectList(movies, "Id", "Title");
            //ViewBag.movieslist = listmovies;

            //var movietypes = db.MovieTypes.ToList();
            //SelectList listmovietypes = new SelectList(movietypes, "Id", "Name");
            //ViewBag.movietypeslist = listmovietypes;
            ViewBag.MoviesList = GetMovieById(1);
            return View();
        }
        public SelectList GetMovieById(int ID)
        {
            var position = db.MoviePositions.Include("Movie").Where(a => a.CinemaId == ID).Select(p => p.Movie);
            db.Configuration.ProxyCreationEnabled = false;
            var positionslist = new SelectList(position, "Id", "Title");
            return positionslist;
        }

        public ActionResult PickedCity(int id)
        {
            var vm = new HomeViewModel()
            {
                //MoviesInPickedCinema = db.Movies.ToList()
            };

            return RedirectToAction("Index", vm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}