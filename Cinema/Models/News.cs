using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class News
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Treść")]
        public string Text { get; set; }
        [Display(Name = "Ścieżka do pliku")]
        public string ImagePath { get; set; }
        [Display(Name = "Nazwa pliku")]
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Ścieżka do pliku")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}