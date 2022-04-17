using System.Text.Json;
using P_One.Database;
using P_One.Logic;
using Microsoft.AspNetCore.Mvc;



namespace P_One.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
      
        private readonly ILogger<PlayerController> _logger;
        private readonly IRepo _repo;

        //public PlayerController(IRepo repo)
        //{
        //    _repo = repo;
        //}

        public PlayerController(ILogger<PlayerController> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("previous")]
        public async Task<ContentResult> GetPreviousPlayersAsync()
        {
            List<Player> playerinfo = await _repo.LastTwoPlayers();

            string json = JsonSerializer.Serialize(playerinfo);

            _logger.LogInformation("Executed PlayerController GetAllPlayersAsync");

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

        }
        [HttpGet("current")]
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
        [HttpGet("current/name")]
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
        [HttpGet("current/inventory")]
        public async Task<ContentResult> GetPlayerInventory(int playerID)
        {
            List<Item> inventory = await _repo.GetInventory(playerID);
            string json = JsonSerializer.Serialize(inventory);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }
        [HttpGet("current/header")]
        public async Task<ContentResult> GetPlayerHeaderAsync(int playerID)
        {
            Player current = await _repo.GetPlayer(playerID);
            string json = JsonSerializer.Serialize(current.PlayerHeader());

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }


        [HttpPut("current/update")]
        public async Task<ContentResult> UpdatePlayerMovesAsync([FromBody] Player current)
        {

            await _repo.UpdatePlayerStats(current);

            return new ContentResult()
            {
                StatusCode = 200,
            };

        }
        [HttpPost("create")]
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
        [HttpPost("create/table")]
        public async Task<ContentResult>MakePlayerItemTable([FromBody] int playerID)
        {
            await _repo.CreatePlayerItemTable(playerID);
            return new ContentResult()
            {
                StatusCode = 200,
            };
        }
        [HttpPost("item/add")]
        public async Task<ContentResult>AddToPlayerInventory([FromBody] Player current)
        {
            await _repo.AddToInventory(current);

            return new ContentResult()
            {
                StatusCode = 200,
            };
        }




        [HttpDelete("delete/table")]
        public async Task<ContentResult>RemovePlayerItemTable(int playerID)
        {
            await _repo.DropPlayerItemTable(playerID);

            return new ContentResult()
            {
                StatusCode = 204
            };
        }
        [HttpDelete("delete")]
        public async Task<ContentResult> DeletePlayerAsync(int playerID)
        {         
            await _repo.RemovePlayer(playerID);

            return new ContentResult()
            {
                StatusCode = 204,
            };
        }
        [HttpDelete("delete/inventory")]
        public async Task<ContentResult>ClearPlayerInventory(int playerID)
        {
            await _repo.EmptyPlayerInventory(playerID);

            return new ContentResult()
            {
                StatusCode = 204,
            };
        }

    }
}