using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Genre
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nazwa gatunku po polsku")]
        public string Name { get; set; }
        [Display(Name = "Nazwa gatunku po angielsku")]
        public string EnglishName { get; set; }
    }
}