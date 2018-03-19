using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class CinemaPlace
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nazwa miasta")]
        public string City { get; set; }
        [Display(Name = "Nazwa miejsca w którym się znajduje kino")]
        public string Name { get; set; }
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Numer")]
        public int Number { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }
        [Display(Name = "Długość geograficzna")]
        public double Longitude { get; set; }
        [Display(Name = "Szerokość geograficzna")]
        public double Latitude { get; set; }
        [NotMapped]
        public string FullName { get { return City + " - " + Name; } }
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public ICollection<MoviePosition>MoviePositions { get; set; }
    }
}