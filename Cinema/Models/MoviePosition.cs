using System;

namespace Cinema.Models
{
    public class MoviePosition
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int MovieTypeId { get; set; }
        public int CinemaId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual MovieType MovieType { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual CinemaPlace Cinema { get; set; }

    }
}