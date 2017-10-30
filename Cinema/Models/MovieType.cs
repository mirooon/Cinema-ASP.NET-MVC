using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class MovieType
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nazwa typu filmu")]
        [MaxLength(20)]
        public string Name { get; set; }
        public ICollection<Movie>Movies { get; set; }
    }
}