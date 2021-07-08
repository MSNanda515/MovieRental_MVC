using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using MovieRental.Dtos;
using MovieRental.Mappings;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRental.Views.Customers.Api
{


    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly IMapper _mapper;



        private AppDbContext _context;

        public CustomersController(IMapper mapper)
        {
            _context = new AppDbContext();
            _mapper = mapper;
        }


        // GET: api/customers
        [HttpGet]
        public IEnumerable<CustomerDto > GetCustomers()
        {
            return _context.Customers.ToList().Select(_mapper.Map<Customer, CustomerDto>);
        }
         
        // GET api/customers/1
        [HttpGet("{id}")]
        public CustomerDto GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return new CustomerDto();

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST api/customers
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.GetEncodedUrl() + "/" + customer.Id), customer);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return;

            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return;
            _mapper.Map(customerDto, customerInDb);

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
