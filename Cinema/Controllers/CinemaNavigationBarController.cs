using Cinema.Context;
using Cinema.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class CinemaNavigationBarController : Controller
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
        public JsonResult Autocomplete(string keyword)
        {
            var cinemas = db.Cinemas.Where(c => (c.City + " - " + c.Name).ToLower().Contains(keyword)).Take(5)
                .Select(a=> (a.City + " - " + a.Name)).ToList();
            return Json(cinemas, JsonRequestBehavior.AllowGet);
        }
    }
}