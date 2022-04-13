using BettaFishApp.DataLogic;
using BettaFishApp.InformationLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BettaFishApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BettaFunFactsController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<BettaFunFactsController> _logger;

        // Constructors
        public BettaFunFactsController(IRepository repository, ILogger<BettaFunFactsController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BettaFunFacts>>> GetAllBettaFunFactsAsyc()
        {
            IEnumerable<BettaFunFacts> bettafunfacts;
            try
            {
                bettafunfacts = await _repository.GetAllBettaFunFacts();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while Betta Fun Facts.");
                return StatusCode(500);
            }
            return bettafunfacts.ToList();
        }

    }
}