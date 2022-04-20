using Microsoft.AspNetCore.Mvc;
using GamesApp.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using GamesApp.DataLogic;

namespace GamesApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<GameController> _logger;

        // Constructors
        public GameController(IRepository repository, ILogger<GameController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGamesAsync()
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repository.GetAllGames();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting all games.");
                return StatusCode(500);
            }
            return games.ToList();
        }
    }
}
