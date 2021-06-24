using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;
using MovieRental.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Radom/
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customerList = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "customer 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                movie = movie,
                customers = customerList
            };
            return View(viewModel);
        }

        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
