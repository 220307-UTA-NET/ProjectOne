using EmployeeApp.BusinessLogic;
using EmployeeApp.DataLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeApp.API.Controllers
{
    // Web API project template provides a starter controller
    [Route("api")]
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
        // Get a single employee
        [HttpGet("employee")]   // GET = SELECT
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

        // Get all employees
        [HttpGet("employees")]   // HttpGet attribute - GET method
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

        // Add a new employee
        [HttpPost("addEmp")]  // POST = INSERT
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

        // Update an employee
        [HttpPut("updateEmp")]   // PUT = UPDATE
        public async Task<ActionResult<IEnumerable<Employee>>> UpdateEmployeeAsync(int Id, Employee emp)
        {
            // IEnumerable containing an Employee
            IEnumerable<Employee> employee;
            try
            {
                employee = await _repository.UpdateEmployeeAsync(Id, emp);  // Run UpdateEmployeeAsync
                _logger.LogInformation("UpdateEmployeeAsync success");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while updating an employee with Id: {0}.", Id);     // Log Error with message
                return StatusCode(500);     // Return StatusCode(500) - server side error - if FAILS
            }
            return employee.ToList();       // Return List<IEnumerable<Employee>> if SUCCESSFUL
        }

        // Delete an employee
        [HttpDelete("deleteEmp")]    // DELETE = DELETE
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
