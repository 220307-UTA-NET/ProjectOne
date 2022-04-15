using EmployeeApp.BusinessLogic;
using EmployeeApp.DataLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeApp.API.Controllers
{
    // ApiController attribute requires routing
    [ApiController]
    [Route("api/[controller]")]

    public class DeleteEmployeeController : ControllerBase
    {
        // Fields
        public readonly IRepository _repository;
        public readonly ILogger<DeleteEmployeeController> _logger;

        // Contstructors
        public DeleteEmployeeController(IRepository repository, ILogger<DeleteEmployeeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // Methods
        [HttpDelete]    // DELETE = DELETE
        public async Task<ActionResult<IEnumerable<Employee>>> DeleteEmployeeAsync(int Id)
        {
            IEnumerable<Employee> employee;
            try
            {
                employee = await _repository.DeleteEmployeeAsync(Id);  // Run DeleteEmployeeAsync
                _logger.LogInformation("DeleteEmployeeAsync success");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while deleting an employee with Id: {0}.", Id);     // Log Error with message
                return StatusCode(500);     // Return StatusCode(500) - server side error - if FAILS
            }
            return employee.ToList();       // Return List<IEnumerable<Employee>> if SUCCESSFUL
        }
    }
}
