using Microsoft.AspNetCore.Mvc;
using StoreApplication.BusinessLogic;
using StoreApplication.DataLogic;
using System.Data.SqlClient;
using System.Text.Json;

namespace ServerApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly InterfaceRepo _repository;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(InterfaceRepo repository, ILogger<CustomerController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpGet("getCustomer/{fname}/{lname}")]
        public async Task<ActionResult<Customer>> GetCustomer(string fname, string lname)
        {
            ContentResult result;
            Customer customer;
            try
            {
                customer = await _repository.GetCustomer(fname, lname);
                string json = JsonSerializer.Serialize(customer);
                result = new ContentResult()
                {
                    StatusCode = 201,
                    ContentType = "application/json",
                    Content = json
                };
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"SQL error while getting customer information {fname} {lname}");
                return StatusCode(500);
            }
            _logger.LogCritical("Critical Event");
            _logger.LogInformation("Information Event");
            _logger.LogTrace("Trace Event");
            return result;
        }
    }
}
