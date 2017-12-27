using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class MoviePosition
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [NotMapped]
        public int MovieTypeId { get; set; }
        public int CinemaId { get; set; }
        public string MovieTitle { get; set; }
        public int MovieDuration { get; set; }
        [NotMapped]
        public List<DateTimeAndMovieTypePair> DateTimeWithMovieType { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual MovieType MovieType { get; set; }
        public virtual CinemaPlace Cinema { get; set; }

    }
}