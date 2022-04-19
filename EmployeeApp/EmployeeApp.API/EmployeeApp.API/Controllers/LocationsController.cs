using EmployeeApp.BusinessLogic;
using EmployeeApp.DataLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeApp.API.Controllers
{
    // Web API project template provides a starter controller
    [Route("api")]
    [ApiController]

    public class LocationsController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<EmployeeController> _logger;

        // Constructors
        public LocationsController(IRepository repository, ILogger<EmployeeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // Methods
        // Get all locations
        [HttpGet("locations")]   // HttpGet attribute - GET method
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync()
        {
            IEnumerable<Location> locations;    // IEnumerable containing Location object
            try
            {
                locations = await _repository.GetLocationsAsync();   // Run GetLocationsAsync()
                _logger.LogInformation("GetLocationsAsync() success");
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting locations.");     // Log Error with message
                return StatusCode(500);     // Return StatusCode(500) - server side error - if FAILS
            }
            return locations.ToList();      // Return List<IEnumerable<Employee>> if SUCCESSFUL
        }

    }
}
