using Cinema.Context;
using Cinema.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class NavigationBarController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        public ActionResult PartialChooseCinemaNavigationBar()
        {
            ChooseCinemaNavigationBarViewModel vm = new ChooseCinemaNavigationBarViewModel()
            {
                Cinemas = db.Cinemas
            };
            return PartialView("_ChooseCinemaNavigationBar", vm);
        }
        [HttpPost]
        public JsonResult AutocompleteCinema(string keyword)
        {
            var cinemas = db.Cinemas.Where(c => (c.City + " - " + c.Name).ToLower().Contains(keyword)).Take(5)
                .Select(a => new SearchNavigationBarAutocomplete { Id = a.Id, FullName= (a.City + " - " + a.Name) }).ToList();
            return Json(cinemas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutocompleteMovieSearch(string keyword)
        {
            var movies = db.Movies.Where(c => (c.OryginalTitle.ToLower().Contains(keyword) || c.Title.ToLower().Contains(keyword))
            && c.Status != Models.Status.Hidden).Take(10).Select(c => new SearchNavigationBarAutocomplete { Id = c.Id, FullName = c.Title }).ToList();
            return Json(movies, JsonRequestBehavior.AllowGet);
        }
    }
}