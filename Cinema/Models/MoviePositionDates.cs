using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class MoviePositionDates
    {
        public int Id { get; set; }
        public int MoviePositionId { get; set; }
        [Display(Name = "Typ filmu")]
        public int MovieTypeId { get; set; }
        [Display(Name = "Termin")]
        public DateTime DateTime { get; set; }

        public virtual MoviePosition MoviePosition { get; set; }
        public virtual MovieType MovieType { get; set; }
    }
}