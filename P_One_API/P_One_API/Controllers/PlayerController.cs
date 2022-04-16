using System.Text.Json;
using Database;
using Logic;
using Microsoft.AspNetCore.Mvc;



namespace P_One_API.Controllers
{
    [ApiController]
    [Route("player/[controller]")]
    public class PlayerController : ControllerBase
    {
      
        private readonly ILogger<PlayerController> _logger;
        private readonly IRepo _repo;

        public PlayerController(ILogger<PlayerController> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("/player/previous")]
        public async Task<ContentResult> GetPreviousPlayersAsync()
        {
            List<string> playerinfo = new List<string>();
            foreach (Player p in await _repo.LastTwoPlayers())
            {
                playerinfo.Add(p.PlayerInfo());
            }

            string json = JsonSerializer.Serialize(playerinfo);

            _logger.LogInformation("Executed PlayerController GetAllPlayersAsync");

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

        }
        [HttpGet("/player/current")]
        public async Task<ContentResult> GetOnePlayerAsync(int playerID)
        {
            var current = await _repo.GetPlayer(playerID);
            string json = JsonSerializer.Serialize(current);
            _logger.LogInformation("Get one player");

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }
        [HttpGet("/player/current/name")]
        public async Task<ContentResult> GetOnePlayerNameAsync(int playerID)
        {
            var current = await _repo.GetPlayer(playerID);
            string json = JsonSerializer.Serialize(current.GetName());

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }


        [HttpPut("/player/current/update")]
        public async Task<ContentResult> UpdatePlayerMovesAsync([FromBody] Player current)
        {

            await _repo.UpdatePlayerStats(current);

            return new ContentResult()
            {
                StatusCode = 200,
            };

        }
        [HttpPost("/player/create")]
        public async Task<ContentResult> AddPlayerAsync([FromBody] string playerName)
        {
            Player player = new Player(playerName);
            string json = await _repo.NewPlayer(player);
            _logger.LogInformation("Player created");

            return new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };
        }
        [HttpPost("/player/create/table")]
        public async Task<ContentResult>MakePlayerItemTable([FromBody] int playerID)
        {
            await _repo.CreatePlayerItemTable(playerID);
            return new ContentResult()
            {
                StatusCode = 200,
            };
        }




        [HttpDelete("/player/delete/table")]
        public async Task<ContentResult>RemovePlayerItemTable(int playerID)
        {
            await _repo.DropPlayerItemTable(playerID);

            return new ContentResult()
            {
                StatusCode = 204
            };
        }
        [HttpDelete("/player/delete")]
        public async Task<ContentResult> DeletePlayerAsync(int playerID)
        {         
            string json = await _repo.RemovePlayer(playerID);

            return new ContentResult()
            {
                StatusCode = 204,
            };
        }

    }
}