using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class AgeRestriction
    {
        [Display(Name = "Ograniczenie wiekowe")]
        public int Id { get; set; }
        [Display(Name = "Nazwa ograniczenia wiekowego")]
        public string Name { get; set; }
        public string EnglishName { get; set; }
        [Display(Name = "Zdjęcie ograniczenia wiekowego")]
        public byte[] Photo { get; set; }
        public string ImagePath { get; set; }
    }
}