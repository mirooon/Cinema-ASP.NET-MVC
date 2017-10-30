using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class AgeRestriction
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa ograniczenia wiekowego(np \"Od 16 lat\")")]
        public string Name { get; set; }
        [Display(Name = "Zdjęcie ograniczenia wiekowego")]
        public byte[] Photo { get; set; }
    }
}