using DemoApp.BusinessLogic;
using DemoApp.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text.Json;

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
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

        // Methods
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomersAsync()
        {
            List<Customer> customers;
            try
            {
                customers = await _repository.GetAllCustomers();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting customer list.");
                return StatusCode(500);
            }
            foreach (Customer item in customers)
            {
                Console.WriteLine(item.getCustFirstName());
                Console.WriteLine(item.getCustLastName());
            }
            return customers;
        }
        [HttpGet("{input}")]

        public async Task<ActionResult<List<Customer>>> GetCustomerAsync(string input)
        {
            List<Customer> customer;
            try
            {
                customer = await _repository.GetCustomer(input);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"SQL error while getting customers by the name of: {input}.");
                return StatusCode(500);
            }
            return customer;
        }



        [HttpPost()]

        public async Task<IActionResult> RegisterCustomerAsync([FromBody]Customer customer)
        {
            // List<Customer> customer;
            try
            {
                await _repository.AddCustomer(customer);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, " Regiateration Failed" + customer);
                return StatusCode(500);


            }

        }

        //PUT Method

        [HttpPut()]

        public async Task<IActionResult> UpdateCustomerAsync([FromBody] Customer customer)
        {
            // List<Customer> customer;
            try
            {
                await _repository.UpdateCustomerAddress(customer);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, " RUpdating Address was Failed" + customer);
                return StatusCode(500);


            }

        }





    }
}