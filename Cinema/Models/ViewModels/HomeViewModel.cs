using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Models.ViewModels
{
    public class HomeViewModel
    {
        public SelectList PickCinema { get; set; }
        public SelectList PickMovie { get; set; }
    }
}