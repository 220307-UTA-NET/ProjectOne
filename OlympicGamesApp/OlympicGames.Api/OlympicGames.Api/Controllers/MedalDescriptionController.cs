using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlympicGames.BusinessLogic;
using OlympicGames.DataLogic;
using System.Data.SqlClient;

namespace OlympicGames.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedalDescriptionController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<OnboardingController> _logger;
        public MedalDescriptionController(IRepository respository, ILogger<OnboardingController> logger)
        {
            this._repository = respository;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Onboarding>>> GetMedalDescriptionAsync()
        {
            IEnumerable<Onboarding> about;
            try
            {
                about = await _repository.GetMedalInfo();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting about");
                return StatusCode(500);
            }
            return about.ToList();
        }

        [HttpGet("MedalStats")]
        public async Task<ActionResult<IEnumerable<Country>>> MedalStats()
        {
            IEnumerable<Country> about;
            try
            {
                about = await _repository.GetCountryMedalInfo();
                //about = await _repository.GetMedalInfo();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting about");
                return StatusCode(500);
            }
            return about.ToList();

        }
    }
}
