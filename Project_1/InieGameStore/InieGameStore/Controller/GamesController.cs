using IndieGameStore.DataInfrastructure;
using IndieGameStore.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace InieGameStore.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        //Fields
        private readonly IRepository _repository;

        //Constructors
        public GamesController(IRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGamesAsyc()
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repository.GetAllGames();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            return games.ToList();

        }
    }
}
