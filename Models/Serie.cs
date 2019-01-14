using System;
using System.ComponentModel.DataAnnotations;

namespace NetflixApp.Models
{
    public class Serie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }
        public int Seasons { get; set; }
        public string Rating { get; set; }
    }
}