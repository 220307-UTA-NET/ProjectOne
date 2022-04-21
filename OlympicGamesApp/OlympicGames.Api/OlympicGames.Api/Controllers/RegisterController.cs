using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlympicGames.BusinessLogic;
using OlympicGames.DataLogic;
using System.Data.SqlClient;

namespace OlympicGames.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<OnboardingController> _logger;
        public RegisterController(IRepository respository, ILogger<OnboardingController> logger)
        {
            this._repository = respository;
            this._logger = logger;
        }

        [HttpPost]
        public async void RegisterConsumer([FromBody] string name)
        {
            try
            {
                await _repository.PostConsumerToDatabase(name);
            }
            catch(SqlException c)
            {
                _logger.LogError(c, "Register Failed. Please try again. ");
            }

        }

    }
}
