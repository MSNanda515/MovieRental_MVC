﻿using System;
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
