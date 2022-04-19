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
            string expectedJson1 = JsonSerializer.Serialize($"New Player {playerName1} added!");
          
            mockRepo.Setup(x => x.NewPlayer(playerName1)).ReturnsAsync(expectedString1);
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
            var actual1 = await playerController.AddPlayerAsync(playerName1);

            //ASSERT
            Assert.Equal(expectedJson1.Trim('"'), actual1.Content);
        }
        [Fact]
        public async Task PlayerController_DeletePlayerAsync_Player_Deleted()
        {

        }
    }
}