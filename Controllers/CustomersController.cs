using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRental.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext _context;

        public CustomersController()
        {
            _context = new AppDbContext();
           
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: customers/
        public IActionResult Index()
        {
            
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cust => cust.Id == id);
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
        private void AddDemoCustomer()
        {
            var demoCust = GetCustomers();
            foreach (Customer cust in demoCust)
            {
                _context.Customers.Add(cust);
            }
            Customer c1 = new Customer { Id = 3, Name = "Lucy" };
            _context.Customers.Add(c1);
            _context.SaveChanges();
        }
    }
}
