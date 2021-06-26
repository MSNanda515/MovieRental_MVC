using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class CustomersController : Controller
    {
        // GET: customers/
        public IActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(cust => cust.Id == id);
            if (customer == null)
                return Content("Page Not found");
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Joy"},
                new Customer {Id = 2, Name = "Kevin"}
            };
        }
    }
}
