using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        [Display(Name = "Tytuł oryginalny")]
        public string OryginalTitle { get; set; }
        [MaxLength(100)]
        [Display(Name = "Obsada")]
        public string Cast { get; set; }
        [Display(Name = "Reżyser")]
        [MaxLength(50)]
        public string Director { get; set; }
        [Display(Name = "Produkcja")]
        [MaxLength(50)]
        public string Production { get; set; }
        [Display(Name = "Data premiery")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Premiere { get; set; }
        [Display(Name = "Czas trwania w minutach")]
        public int Duration { get; set; }
        [Display(Name = "Opis filmu")]
        [MaxLength(300)]
        public string Description { get; set; }
        [Display(Name = "Link do trailera na platformie YouTube")]
        public string TrailerLinkYoutube { get; set; }
        [Display(Name = "Plakat")]
        public byte[] Photo { get; set; }
        [Display(Name = "Wymagany wiek")]
        public int AgeRestrictionId { get; set; }

        public AgeRestriction AgeRestriction { get; set; }
        public virtual ICollection<Genre>Genres { get; set; }
        public virtual ICollection<MoviePosition> MoviePositions { get; set; }
    }
}