using StoreApp0.BusinessLogic;
using StoreApp0.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using StoreApp0.Api.DTO;

namespace StoreApp0.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<CustomersController> _logger;

        // Constructors
        public CustomersController(IRepository repository, ILogger<CustomersController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] AddCustomerDTO customer)
        {

            var id = await _repository.CreateCustomer(customer.FirstName, customer.LastName);
            if(id==0)
            {
                return BadRequest("Customer can not be created");
            }
            return Ok(id);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            CustomerDTO customerDTO;
            try
            {
                var customer = await _repository.GetCustomerById(id);
                if (customer == null)
                    return NotFound($"Customer with Id={id} doesn't exists");
                customerDTO = new CustomerDTO()
                {
                    Id = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting devices named {id}.", id);
                return StatusCode(500);
            }
            return Ok(customerDTO);
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomersAsyc()
        {
            List<CustomerDTO> customerDTOs = null;
            try
            {
                var customers = await _repository.GetAllCustomers();
                if (!customers.Any())
                    return NotFound("No Customers exist");
                customerDTOs = new List<CustomerDTO>();
                foreach(var customer in customers)
                    customerDTOs.Add(new CustomerDTO()
                    {
                        Id = customer.CustomerId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName
                    });
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting Customers.");
                return StatusCode(500);
            }
            return Ok(customerDTOs);
        }
    }
}
