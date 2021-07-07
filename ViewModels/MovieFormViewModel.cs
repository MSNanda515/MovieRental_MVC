using System;
using System.Collections.Generic;
using MovieRental.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime DateReleased { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int QuantStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            DateReleased = movie.DateReleased;
            QuantStock = movie.QuantStock;
            GenreId = movie.GenreId;
        }
    }
}
