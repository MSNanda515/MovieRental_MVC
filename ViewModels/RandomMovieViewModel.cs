using System;
using System.Collections.Generic;

using MovieRental.Models;
namespace MovieRental.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie movie { get; set; }
        public List<Customer> customers { get; set; }

        public RandomMovieViewModel()
        {

        }
    }
}
