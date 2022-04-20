using System.Collections.Generic;
using P_One.Database;
using P_One.Logic;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace P_One.Tests
{
    public class UnitTest1
    {
       
       

        [Fact]
        public async Task PlayerController_GetPreviousPlayerAsync_RetrievesTwoMostRecentPlayers()
        {
            //ARRANGE
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.PlayerController>> mocklog = new();
            Player player1 = new Player("testfname", 2, 3, 4, 5);
            Player player2 = new Player("testName2", 6, 7, 8, 9);
            List<Player> expectedList = new List<Player>() { player1, player2 };
            string expectedJson = JsonSerializer.Serialize(expectedList);
 
            mockRepo.Setup(x => x.LastTwoPlayers()).ReturnsAsync(expectedList);          
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
            var actual = await playerController.GetPreviousPlayersAsync();

            //ASSERT
            Assert.Equal(expectedJson, actual.Content);
            //Assert.Equal(expectedList.Contains(player1), actualList.Contains(player1));
            //Assert.Equal(expectedList.Contains(player2), actualList.Contains(player2));
        }

        [Fact]

        public async Task PlayerController_GetPlayerInventory_RetrievesAllItemsForAPlayer()
        {
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.PlayerController>> mocklog = new();
            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();
            int playerID = 1;
            List<Item> expectedList = new List<Item>() { item1, item2, item3, item4 };   
            string expectedJson = JsonSerializer.Serialize(expectedList);
            int expectedStatusCode = 200;
            mockRepo.Setup(x => x.GetInventory(playerID)).ReturnsAsync(expectedList);          
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
           var actual = await playerController.GetPlayerInventory(playerID);

            //ASSERT
            Assert.Equal(expectedJson, actual.Content);
            Assert.Equal(expectedStatusCode, actual.StatusCode);
         

        }
        [Fact]
        public async Task PlayerController_GetOnePlayerAsync_RetrievesOnePlayers()
        {
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.PlayerController>> mocklog = new();
            Player player1 = new Player("testName1", 2, 3, 4, 5);
            Player player2 = new Player("testName2", 6, 7, 8, 9);
            string player2Json = JsonSerializer.Serialize(player2);
            string player1Json = JsonSerializer.Serialize(player1);
            int expectedStatusCode = 200;
            mockRepo.Setup(x => x.GetPlayer(2)).ReturnsAsync(player1);
            mockRepo.Setup(x => x.GetPlayer(6)).ReturnsAsync(player2);
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
            var actual1 = await playerController.GetOnePlayerAsync(2);
            var actual2 = await playerController.GetOnePlayerAsync(6);

            //ASSERT
            Assert.Equal(player2Json, actual2.Content);
            Assert.Equal(player1Json, actual1.Content);
            Assert.Equal(expectedStatusCode, actual2.StatusCode);
            Assert.Equal(expectedStatusCode, actual1.StatusCode);

        }
        [Fact]
        public async Task PlayerController_AddPlayerAsync_PlayerAdded()
        {
            //ARRANGE
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.PlayerController>> mocklog = new();
            string playerName1 = "testName1";
            string expectedString1 = $"New Player {playerName1} added!";
          
            mockRepo.Setup(x => x.NewPlayer(playerName1)).ReturnsAsync(expectedString1);
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
            var actual1 = await playerController.AddPlayerAsync(playerName1);

            //ASSERT
            Assert.Equal(expectedString1, actual1.Content);
        }
        [Fact]
        public async Task RoomController_GetCurrentRoom_GetOneRoom()
        {
            //ARRANGE
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.RoomController>> mocklog = new();
            Room expected = new Room("Cave", "Dark", 1,2,3);
            int roomID = 2;
            string expectedJson = JsonSerializer.Serialize(expected);
            mockRepo.Setup(x => x.GetRoom(roomID)).ReturnsAsync(expected);         
            var roomController = new API.Controllers.RoomController(mocklog.Object, mockRepo.Object);

            //ACT
            var room = await roomController.GetRoomCurrentAsync(roomID);

            //ASSERT
            Assert.Equal(expectedJson, room.Content);

        }
        [Fact]
        public async Task RoomController_GetOneRoomInventoryAsync_GetListOfRoomItems()
        {
            //ARRAGNE
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.RoomController>> mocklog = new();
            Room expected = new Room("Cave", "Dark", 1, 2, 3);
            List<Item> expectedRoomInventory = new List<Item>();
            Item item = new Item(1,"test1",4);
            Item item2 = new Item(2, "test2", 5);
            Item item3 = new Item(3, "test3", 6);
            expectedRoomInventory.Add(item);
            expectedRoomInventory.Add(item2);
            expectedRoomInventory.Add(item3);
            string inventoryJson= JsonSerializer.Serialize(expectedRoomInventory);
            int[] info = new int[] { 2, 3 };           
            mockRepo.Setup(x => x.GetRoomInventory(info[0], info[1])).ReturnsAsync(expectedRoomInventory);
            var roomController = new API.Controllers.RoomController(mocklog.Object, mockRepo.Object);

            //ACT
            var actualInventory = await roomController.GetOneRoomInventoryAsync( info);

            //ASSERT
            Assert.Equal(inventoryJson, actualInventory.Content);
        }

        [Fact]
        public async Task PlayerController_GetPlayerInventory_GetPlayerItems()
        {
            //ARRANGE
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.PlayerController>> mocklog = new();
            int playerID = 2;
            List<Item> expectedInventory = new();
            expectedInventory.Add(new Item(1, "testitem1", 4));
            expectedInventory.Add(new Item(2, "testitem2", 5));
            string expectedJson = JsonSerializer.Serialize(expectedInventory);

            mockRepo.Setup(x => x.GetInventory(playerID)).ReturnsAsync(expectedInventory);
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
            var actual1 = await playerController.GetPlayerInventory(playerID);

            //ASSERT
            Assert.Equal(expectedJson, actual1.Content);
        }

    }
}