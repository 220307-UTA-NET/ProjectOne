using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamesApp.DataLogic;
using System.Data.SqlClient;
using GamesApp.BusinessLogic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreateGameController : Controller
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<CreateGameController> _logger;

        // Constructors
        public CreateGameController(IRepository repository, ILogger<CreateGameController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Game>>> CreateNewGameAsync(Game newGame)
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repository.CreateNewGame(newGame);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while creating a game.");
                return StatusCode(500);
            }
            return games.ToList();
        }
    }
}

