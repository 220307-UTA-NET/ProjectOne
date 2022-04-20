using BettaFishApi.DataLogic;
using BettaFishApi.Logic;
using System.Threading.Tasks;
using Xunit;

namespace BettaFishApi.Test2
{
    public class BettaStoryTest
    {
        [Fact]
        public void CreateStoryObject_ValidStory()
        {
            //Arrange 
            BettaStories test = new BettaStories(25, "Trance", "Lazer was cool!");

            //Act
            string acutal = test.GetNameOfBetta();

            //Assert
            string expected = "Trance";
            Assert.Equal(expected, acutal);
        }

        [Fact]
        public async Task BettaStory_GetBettaStories_ValidStory()
        {

            Mock<IRepository> mockRepo = new();
            BettaStories test = new BettaStories(25, "Trance", "Lazer was cool!");
            Task BettaStories happy4 = new Task BettaStories();
            happy2.Add(test);

            string json = JsonSerializer.Serialize(happy4);
            Mock<ILogger<BettaFishApi.DataLogic.Controllers.BettaFishController>> mocklog = new();

            mockRepo.Setup(x => x.GetAllWebRegistrationAsync()).ReturnsAsync(happy4);
            var bettalist3 = new BettaFishApi.DataLogic.Controllers.BettaFishController(mockRepo.Object, mocklog.Object);

            //act
            var test50 = await bettalist3.GetAllWebRegistrationAsync();

            //assert
            Assert.Equal(json, test50.Content);

        }









    
    }
}