using BettaFishApi.DataLogic;
using BettaFishApi.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;

namespace BettaFishApi.DataLogic.Controllers
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

        [HttpGet("/betta/get/type")]
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

        [HttpGet("/betta/get/description")]
        public async Task<ContentResult> GetBettaDescriptionAsync()
        {
            List<BettaType> bettadescription = await _repository.GetBettaDescriptionAsync();
            string json = JsonSerializer.Serialize(bettadescription);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }

        [HttpGet("/betta/get/funfacts")]
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

        [HttpGet("/betta/get/storelocation")]
        public async Task<ContentResult> GetAllStoreLocationAsync()
        {
            List<BettaStoreLocation> storelocation = await _repository.GetAllStoreLocationAsync();
            string json = JsonSerializer.Serialize(storelocation);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

        }

        [HttpGet("/betta/view/fanstories")]
        public async Task<ContentResult> GetAllBettaStoriesAsync()
        {
            List<BettaStories> bettafanstories = await _repository.GetAllBettaFanStoriesAsync();
            string json = JsonSerializer.Serialize(bettafanstories);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }

        [HttpGet("/betta/view/registration")]
        public async Task<ContentResult> GetAllWebRegistrationAsync()
        {
            List<BettaRegistration> viewregistration = await _repository.GetAllWebRegistrationAsync();
            string json = JsonSerializer.Serialize(viewregistration);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
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

        [HttpPost("/betta/stories")]
        public async Task<IActionResult> GetBettaStoriesAsync(BettaStories bettastories)
        {

            try
            {
                await _repository.GetBettaStories(bettastories);
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
