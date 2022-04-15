using EmployeeApp.BusinessLogic;
using EmployeeApp.DataLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeApp.API.Controllers
{
    // Web API project template provides a starter controller
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<EmployeeController> _logger;

        // Constructors
        public EmployeesController(IRepository repository, ILogger<EmployeeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // Methods
        [HttpGet]   // HttpGet attribute - GET method
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
        {
            IEnumerable<Employee> employees;    // IEnumerable containing Employee object
            try
            {
                employees = await _repository.GetAllEmployeesAsync();   // Run GetAllEmployeesAsync()
                _logger.LogInformation("GetAllEmployeesAsync success");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting all employees.");     // Log Error with message
                return StatusCode(500);     // Return StatusCode(500) - server side error - if FAILS
            }
            return employees.ToList();      // Return List<IEnumerable<Employee>> if SUCCESSFUL
        }
    }
}
