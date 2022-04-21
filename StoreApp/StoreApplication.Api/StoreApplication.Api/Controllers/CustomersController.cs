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
    public class CustomersController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<CustomerController> _logger;

        // Constructors
        public CustomersController(IRepository repository, ILogger<CustomerController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        // [TestMethod]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsyc()
        {
            IEnumerable<Customer> customers;
            try
            {
                customers = await _repository.GetAllCustomers();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting customers.");
                return StatusCode(500);
            }
            return customers.ToList();
        }  

    }
}