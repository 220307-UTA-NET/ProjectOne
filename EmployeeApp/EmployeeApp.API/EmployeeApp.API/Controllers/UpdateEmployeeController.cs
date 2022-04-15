using EmployeeApp.BusinessLogic;
using EmployeeApp.DataLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeApp.API.Controllers
{
    // ApiController attribute requires it to need routing
    [ApiController]
    [Route("api/[controller]")]

    public class UpdateEmployeeController : ControllerBase
    {
        // Fields
        public readonly IRepository _repository;
        public readonly ILogger<AddEmployeeController> _logger;

        // Constructors
        public UpdateEmployeeController(IRepository repository, ILogger<AddEmployeeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // Methods
        [HttpPut]   // PUT = UPDATE
        public async Task<ActionResult<IEnumerable<Employee>>> UpdateEmployeeAsync(Employee emp)
        {
            // IEnumerable containing an Employee
            IEnumerable<Employee> employee;
            try
            {
                employee = await _repository.UpdateEmployeeAsync(emp);  // Run UpdateEmployeeAsync
                _logger.LogInformation("UpdateEmployeeAsync success");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while updating an employee with Id: {0}.", emp.Id);     // Log Error with message
                return StatusCode(500);     // Return StatusCode(500) - server side error - if FAILS
            }
            return employee.ToList();       // Return List<IEnumerable<Employee>> if SUCCESSFUL
        }


    }
}
