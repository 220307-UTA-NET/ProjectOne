using BettaFishApi.DataLogic;
using BettaFishApi.Logic;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;


namespace BettaFishApi.Test
{
    public class BettaRegistrationTest
    {
        [Fact]
        public void CreateRegistrationObject_ValidRegistration()
        {
            //Arrange 
            BettaRegistration test = new BettaRegistration(23, "Cali", "Swag", "cali.swag@gmail.com");

            //Act
            string acutal = test.GetfName();

            //Assert
            string expected = "Cali";
            Assert.Equal(expected, acutal);
        }

        [Fact]
        public async Task BettaRegistration_GetAllWebBRegistration_ValidPerson()
        {
            
            Mock<IRepository> mockRepo = new();
            BettaRegistration test = new BettaRegistration(23, "Cali", "Swag", "cali.swag@gmail.com");
            List<BettaRegistration> happy = new List<BettaRegistration>(); 
            happy.Add(test);

            string json = JsonSerializer.Serialize(happy);
            Mock<ILogger<BettaFishApi.DataLogic.Controllers.BettaFishController>> mocklog = new();

            mockRepo.Setup(x => x.GetAllWebRegistrationAsync()).ReturnsAsync(happy);
            var bettalist = new BettaFishApi.DataLogic.Controllers.BettaFishController(mockRepo.Object, mocklog.Object);

            //act
            var test88 = await bettalist.GetAllWebRegistrationAsync();

            //assert
            Assert.Equal(json, test88.Content);

        }

        [Fact]
        public void CreateRegistrationObject2_ValidRegistration()
        {
            //Arrange 
            BettaRegistration test = new BettaRegistration(24, "Cali", "Swag", "cali.swag@gmail.com");

            //Act
            string acutal = test.GetlName();

            //Assert
            string expected = "Swag";
            Assert.Equal(expected, acutal);
        }

        [Fact]
        public async Task BettaRegistration_GetAllWebBRegistration_ValidPerson2()
        {

            Mock<IRepository> mockRepo = new();
            BettaRegistration test = new BettaRegistration(24, "Cali", "Swag", "cali.swag@gmail.com");
            List<BettaRegistration> happy1 = new List<BettaRegistration>();
            happy1.Add(test);

            string json = JsonSerializer.Serialize(happy1);
            Mock<ILogger<BettaFishApi.DataLogic.Controllers.BettaFishController>> mocklog = new();

            mockRepo.Setup(x => x.GetAllWebRegistrationAsync()).ReturnsAsync(happy1);
            var bettalist1 = new BettaFishApi.DataLogic.Controllers.BettaFishController(mockRepo.Object, mocklog.Object);

            //act
            var test89 = await bettalist1.GetAllWebRegistrationAsync();

            //assert
            Assert.Equal(json, test89.Content);

        }

        [Fact]
        public void CreateRegistrationObject3_ValidRegistration()
        {
            //Arrange 
            BettaRegistration test = new BettaRegistration(25, "Cali", "Swag", "cali.swag@gmail.com");

            //Act
            string acutal = test.Getemail();

            //Assert
            string expected = "cali.swag@gmail.com";
            Assert.Equal(expected, acutal);
        }

        [Fact]
        public async Task BettaRegistration_GetAllWebBRegistration_ValidPerson3()
        {

            Mock<IRepository> mockRepo = new();
            BettaRegistration test = new BettaRegistration(25, "Cali", "Swag", "cali.swag@gmail.com");
            List<BettaRegistration> happy2 = new List<BettaRegistration>();
            happy2.Add(test);

            string json = JsonSerializer.Serialize(happy2);
            Mock<ILogger<BettaFishApi.DataLogic.Controllers.BettaFishController>> mocklog = new();

            mockRepo.Setup(x => x.GetAllWebRegistrationAsync()).ReturnsAsync(happy2);
            var bettalist2 = new BettaFishApi.DataLogic.Controllers.BettaFishController(mockRepo.Object, mocklog.Object);

            //act
            var test90 = await bettalist2.GetAllWebRegistrationAsync();

            //assert
            Assert.Equal(json, test90.Content);

        }

    }
}