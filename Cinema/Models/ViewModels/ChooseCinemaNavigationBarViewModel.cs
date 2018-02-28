using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.ViewModels
{
    public class ChooseCinemaNavigationBarViewModel
    {
        public IEnumerable<CinemaPlace> Cinemas { get; set; }
    }
}