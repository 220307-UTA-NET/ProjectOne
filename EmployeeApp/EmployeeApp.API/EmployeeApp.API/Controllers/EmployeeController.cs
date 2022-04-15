using EmployeeApp.BusinessLogic;
using EmployeeApp.DataLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeApp.API.Controllers
{
    // Web API project template provides a starter controller
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<EmployeeController> _logger;
        
        // Constructors
        public EmployeeController(IRepository repository, ILogger<EmployeeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        // Methods
        [HttpGet]   // GET = SELECT
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeAsync(int Id)
        {
            IEnumerable<Employee> employee;     // IEnumerable containing Employee object
            try
            {
                employee = await _repository.GetEmployeeAsync(Id);      // Run GetEmployeeAsync()
                _logger.LogInformation("GetEmployeeAsync success");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting an employee with id: {0}.", Id);     // Log Error with message
                return StatusCode(500);     // Return StatusCode(500) - server side error - if FAILS
            }
            return employee.ToList();       // Return List<IEnumerable<Employee>> if SUCCESSFUL
        }
    }
}
