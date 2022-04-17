using BettaFishApp.DataLogic;
using BettaFishApp.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;

namespace BettaFishAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BettaFishController : ControllerBase
    {

        private readonly IRepository _repository;
        private readonly ILogger<BettaFishController> _logger;

        // Constructors
        public BettaFishController(IRepository repository, ILogger<BettaFishController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpGet("/betta/type")]
        public async Task<ActionResult<IEnumerable<BettaType>>> GetAllBettaTypeAsyc()
        {
            IEnumerable<BettaType> bettatypes;
            try
            {
                bettatypes = await _repository.GetAllBettaTypeAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting Betta Type");
                return StatusCode(500);
            }
            return bettatypes.ToList();
        }

        [HttpGet("/betta/funfacts")]
        public async Task<ActionResult<IEnumerable<BettaFunFacts>>> GetAllBettaFunFactsAsyc()
        {
            IEnumerable<BettaFunFacts> bettafunfacts;
            try
            {
                bettafunfacts = await _repository.GetAllBettaFunFactsAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while Betta Fun Facts.");
                return StatusCode(500);
            }
            return bettafunfacts.ToList();
        }


        [HttpPost("/betta/registration")]
        public async Task<IActionResult> WebRegistrationAsync(BettaRegistration bettaregistration)
        {
            
            try
            {
                await _repository.WebRegistration(bettaregistration);
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
