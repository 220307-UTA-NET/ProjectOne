using BettaFishApp.DataLogic;
using BettaFishApp.InformationLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;

namespace BettaFishApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<RegistrationController> _logger;

        // Constructors
        public RegistrationController(IRepository repository, ILogger<RegistrationController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

       //Methods
       [HttpPost("/registration")]
        public async Task<IActionResult> WebRegistrationAsync(Registration registration)
        {
            //List<Registration> registrations;
            try
            {
                await _repository.WebRegistration(registration);
                return StatusCode(200);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Register Failed. Please try again. ");
                return StatusCode(500);
            }
          
        }

    }
}
