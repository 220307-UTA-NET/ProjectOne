using BookStore.Domain;
using BookStore.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _repo = customerRepository;
        }

        [HttpGet("api/customers")]
        public IEnumerable<Domain.Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        [HttpGet("api/customers/{id?}")]
        public Domain.Customer GetCustomerByID(int id)
        {
            return _repo.GetCustomerByID(id);
        }

        [HttpPost("api/customers")]
        public void AddCustomer(Domain.Customer c)
        {
            _repo.AddCustomer(c);
        }

        [HttpPut("api/customers")]
        public void UpdateCustomer(Domain.Customer c)
        {
            _repo.UpdateCustomer(c);
        }

        [HttpDelete("api/customers")]
        public void DeleteCustomer(Domain.Customer c)
        {
            _repo.DeleteCustomer(c);
        }
    }
}
