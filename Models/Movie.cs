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

        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateReleased { get; set; }

        public int QuantStock { get; set; }

        public int AvailStock { get; set; }
    }
}
