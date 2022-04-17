using System.Text.Json;
using P_One.Database;
using P_One.Logic;
using Microsoft.AspNetCore.Mvc;

namespace P_One.API.Controllers
{
    [ApiController]
    [Route("room/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRepo _repo;

        public RoomController(ILogger<RoomController> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }



        [HttpGet("/room/current/inventory")]
        public async Task<ContentResult> GetOneRoomInventoryAsync([FromQuery] int[] r_pID)
        {
            List<Item> roomInventory = await _repo.GetRoomInventory(r_pID[0], r_pID[1]);
            string json = JsonSerializer.Serialize(roomInventory);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }
        [HttpGet("/room/current")]
        public async Task<ContentResult> GetRoomCurrentAsync(int roomID)
        {
            var currentRoom = await _repo.GetRoom(roomID);
            string json = JsonSerializer.Serialize(currentRoom);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }
        [HttpGet("/room/adjacent")]
        public async Task<ContentResult> GetAdjRoomsAsync([FromQuery] Room current)
        {

            Room adjRoom1 = await _repo.GetRoom(current.adjRoom1);
            Room adjRoom2 = await _repo.GetRoom(current.adjRoom2);
            Room adjRoom3 = await _repo.GetRoom(current.adjRoom3);

            List<Room> adjRooms = new() { adjRoom1, adjRoom2, adjRoom3 };

            string json = JsonSerializer.Serialize(adjRooms);

            return new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };
        }


        [HttpPost("/room/inventory/fill")]
        public async Task<ContentResult> FillAllRoomsInventoryAsync([FromBody] int playerID)
        {
            await _repo.FillAllRooms(playerID);

            _logger.LogInformation("Player table filled");

            return new ContentResult()
            {
                StatusCode = 200,
            };
        }

        [HttpPut("/room/item/delete")]
        public async Task<ContentResult> UpdateItemQuantityAsync(R_P_I_DTO combo)
        {
            await _repo.UpdateItemQuantity(combo);

            return new ContentResult()
            {
                StatusCode = 204
            };
        }
        [HttpDelete("/room/inventory/delete")]
        public async Task<ContentResult> DeleteRoomInventoryAsync()
        {
            await _repo.EmptyAllRooms();

            return new ContentResult()
            {
                StatusCode = 204
            };
        }
    }
}
