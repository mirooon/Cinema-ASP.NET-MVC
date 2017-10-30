using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Genre
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nazwa gatunku")]
        public string Name { get; set; }
        public ICollection<Movie>Movies { get; set; }
    }
}