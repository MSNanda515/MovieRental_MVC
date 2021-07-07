using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;
using MovieRental.ViewModels;

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
            //AddDemoCustomer();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(cust => cust.Id == id);
            if (customer == null)
                return Content("Page Not found");
            return View(customer);
        }

        public IActionResult New()
        {
            var membership = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membership
            };
            return View("CustomerForm",viewModel);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return Content("Page not found");
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                     Customer = customer,
                     MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                // new customer
                _context.Customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToLetter = customer.IsSubscribedToLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        private IEnumerable<Customer> GetCustomers()
        {
            MembershipType m1 = new MembershipType { Id = 1, DiscountRate = 0, DurationMonths = 0, SignUpFee = 0 };
            MembershipType m2 = new MembershipType { Id = 2, DiscountRate = 10, DurationMonths = 3, SignUpFee = 30 };

            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Joy", IsSubscribedToLetter = false,  MembershipTypeId = 1},
                new Customer {Id = 2, Name = "Kevin", IsSubscribedToLetter = true,  MembershipTypeId = 2}
            };
        }
        private void AddDemoCustomer()
        {
            //var demoCust = GetCustomers();
            //foreach (Customer cust in demoCust)
            //{
            //    _context.Customers.Add(cust);
            //}
            //Customer c1 = new Customer { Id = 3, Name = "Lucy" };
            Customer c1 = new Customer { Id = 4, Name = "Willian Jones", IsSubscribedToLetter = false, MembershipTypeId = 3, Birthdate = new DateTime(2000, 10, 20) };
            _context.Customers.Add(c1);
            _context.SaveChanges();
        }
    }
}
