using System;
using System.Collections.Generic;
using MovieRental.Models;

namespace MovieRental.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title { get; set; }
    }
}
