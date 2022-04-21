using Microsoft.AspNetCore.Mvc;
using StoreApplication.BusinessLogic;
using StoreApplication.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace StoreApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<CustomerController> _logger;

        // Constructors
        public CustomerController(IRepository repository, ILogger<CustomerController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods // Get customers by id
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerByNameAsync(string id)
        {
            IEnumerable<Customer> customers;
            try
            {
                customers = await _repository.GetCustomer(id);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting customers named {id}.", id);
                return StatusCode(500);
            }
            return customers.ToList();
        }

         [HttpPost]
         [Route("CreateRecord")]
          public async Task<ActionResult<IEnumerable<Customer>>> PostCustomerRecords(Customer customer)
            {
            IEnumerable<Customer> customers;
            customers=await _repository.AddCustomer(customer);
            //  await _repository.SaveChangesAsync();
            return customers.ToList();

             }
          [HttpDelete]
          [Route("Delete")]
        public async Task<ActionResult<IEnumerable<Customer>>> DeleteCustomerByNameAsync(string id)
        {
            IEnumerable<Customer> customers;
            try
            {
                customers = await _repository.DeleteCustomer(id);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting customers named {id}.", id);
                return StatusCode(500);
            }
            return customers.ToList();
        }
    }
}





