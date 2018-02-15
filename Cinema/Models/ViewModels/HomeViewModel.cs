using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CinemaPlace> Cinemas { get; set; }
        public IEnumerable<Movie> MovieNowBooking { get; set; }
        public IEnumerable<Movie> MovieSoon { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}