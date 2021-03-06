using System;
using System.ComponentModel.DataAnnotations;
namespace MovieRental.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime DateReleased { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int QuantStock { get; set; }

        public int AvailStock { get; set; }
    }
}
