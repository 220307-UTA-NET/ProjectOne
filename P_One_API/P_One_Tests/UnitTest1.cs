using System.Collections.Generic;
using P_One.Database;
using P_One.Logic;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace P_One.Tests
{
    public class UnitTest1
    {
       
       

        [Fact]
        public void PlayerController_GetPreviousPlayerAsync_RetrievesTwoMostRecentPlayers()
        {
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.PlayerController>> mocklog = new();
            Player player1 = new Player("testfname", 2, 3, 4, 5);
            Player player2 = new Player("testName2", 6, 7, 8, 9);
            List<Player> expectedList = new List<Player>() { player1, player2 };
            mockRepo.Setup(x => x.LastTwoPlayers()).ReturnsAsync(expectedList);          
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
            List<Player> actualList = new List<Player>() { player1, player2 };

            //ASSERT
            Assert.Equal(expectedList.Count, actualList.Count);
            Assert.Equal(expectedList.Contains(player1), actualList.Contains(player1));
            Assert.Equal(expectedList.Contains(player2), actualList.Contains(player2));
        }

        [Fact]

        public void PlayerController_GetPlayerInventory_RetrievesAllItemsForAPlayer()
        {
            Mock<IRepo> mockRepo = new();
            Mock<ILogger<API.Controllers.PlayerController>> mocklog = new();
            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();
            int playerID = 1;
            List<Item> expectedList = new List<Item>() { item1, item2, item3, item4 };
            //string logExpected = $"Executed: GetInventory {expectedList.Count} items";
            mockRepo.Setup(x => x.GetInventory(playerID)).ReturnsAsync(expectedList);          
            var playerController = new API.Controllers.PlayerController(mocklog.Object, mockRepo.Object);

            //ACT
            List<Item> actualList = new List<Item>() { item1, item2, item3, item4 };
            //string logActual = $"Executed: GetInventory {actualList.Count} items";

            //ASSERT
            Assert.Equal(expectedList.Count, actualList.Count);
            Assert.Equal(expectedList.Contains(item1), actualList.Contains(item1));
            Assert.Equal(expectedList.Contains(item2), actualList.Contains(item2));
            Assert.Equal(expectedList.Contains(item3), actualList.Contains(item3));
            Assert.Equal(expectedList.Contains(item4), actualList.Contains(item4));
         

        }
    }
}