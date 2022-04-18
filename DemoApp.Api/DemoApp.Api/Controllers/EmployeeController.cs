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
    public class EmployeeController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<EmployeeController> _logger;

        // Constructors
        public EmployeeController(IRepository repository, ILogger<EmployeeController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployeesAsync()
        {
            List<Employee> employees;
            try
            {
                employees = await _repository.GetAllEmployees();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting employee list.");
                return StatusCode(500);
            }
            return employees;
        }
        [HttpGet("{input}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeAsync(string input)
                {
                    List<Employee> employee;
                    try
                    {
                        employee = await _repository.GetEmployee(input);
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError(ex, $"SQL error while searching for employee: {input}.");
                        return StatusCode(500);
                    }
                    return employee;
                }
            }
}
