using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;
using Microsoft.EntityFrameworkCore;
using MovieRental.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        private AppDbContext _context;

        public MoviesController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get /Movies/
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            //var movies = GetMovies();
            //AddMovies();
            var movies = _context.Movies.Include(mov => mov.Genre).ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(mov => mov.Genre).SingleOrDefault(mov => mov.Id == id);
            if (movie == null)
                return Content("Page not found");
            return View(movie);
        }

        private void AddMovies()
        {
            Movie mov = new Movie { Id = 1, Name = "Avengers", GenreId = 1, DateAdded = new DateTime(2019, 10, 5), DateReleased = new DateTime(2019, 8, 4), AvailStock = 4, QuantStock = 4 };
            _context.Movies.Add(mov);
            _context.SaveChanges();
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Pokemon"},
                new Movie { Id = 2, Name = "Iron Man"}
            };
        }

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

        

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
