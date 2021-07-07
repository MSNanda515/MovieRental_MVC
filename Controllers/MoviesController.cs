using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;
using Microsoft.EntityFrameworkCore;
using MovieRental.ViewModels;

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

        /// Action for a new movie form
        /// Returns IActionResult
        public IActionResult New()
        {
            var Genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {

                Genres = Genres,
            };
            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {  
                    Genres = _context.Genres.ToList(),
                };

                return View("MoviesForm", viewModel);
            }
            
            if (movie.Id == 0)
                _context.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(mov => mov.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.DateReleased = movie.DateReleased;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.QuantStock = movie.QuantStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(mov => mov.Id == id);
            if (movie == null)
            {
                return Content("Page Not found");
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList(),
            };
            return View("MoviesForm", viewModel);
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
