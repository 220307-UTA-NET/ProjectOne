using EmployeeApp.BusinessLogic;
using EmployeeApp.DataLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddEmployeeController : ControllerBase
    {
        // Fields
        public readonly IRepository _repository;
        public readonly ILogger<AddEmployeeController> _logger;
            
        // Constructors
        public AddEmployeeController(IRepository repository, ILogger<AddEmployeeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // Methods
        [HttpPost]  // POST = INSERT
        public async Task<ActionResult<IEnumerable<Employee>>> AddEmployeeAsync(Employee emp)
        {
            IEnumerable<Employee> employee;     // IEnumerable containing Employee object
            try
            {
                employee = await _repository.AddEmployeeAsync(emp);  // Run AddEmployeeAsync
                _logger.LogInformation("AddEmployeeAsync success");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting adding a new employee.");     // Log Error with message
                return StatusCode(500);     // Return StatusCode(500) - server side error - if FAILS
            }
            return employee.ToList();       // Return List<IEnumerable<Employee>> if SUCCESSFUL
        }
    }
}
