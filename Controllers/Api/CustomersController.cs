using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Views.Customers.Api
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private AppDbContext _context;

        public CustomersController()
        {
            _context = new AppDbContext();
        }


        // GET: api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
         
        // GET api/customers/1
        [HttpGet("{id}")]
        public Customer GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return new Customer();

            return customer;
        }

        // POST api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return null;
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return;

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return;
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToLetter = customer.IsSubscribedToLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
             
            if (CustomerInDb == null)
                return;

            _context.Customers.Remove(CustomerInDb);
            _context.SaveChanges();
        }
    }
}
