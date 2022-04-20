using Xunit;
using Project1.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Project1.DataLogic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text.Json;

namespace Project1.ApiTest
{
    public class UnitTest1
    {

        [Fact]
        public void UserRegisterationTest()
        {
            //Arrange
            User test = new User(6, "June", "Lee", "Gemini", "Pearl");

            //Act
            string actual = test.GetbankUserUsername();

            //Assert
            string expected = "Gemini";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task UserRegisterationTest_ValidUser()
        {
            //Arrange
            Mock<IRepository> mockRepo = new();
            User test = new User(6,"June","Lee","Gemini","Pearl");
            List <User> newUser = new List<User>();
            newUser.Add(test);

            string json = JsonSerializer.Serialize(newUser);
            Mock<ILogger<Project1.Api.Controllers.LoginController>> mocklog = new();

            mockRepo.Setup(x => x.GetAllUsers()).ReturnsAsync(newUser);
            var userList = new Project1.Api.Controllers.LoginController(mockRepo.Object, mocklog.Object);

            //Act
            var newUserTest = await userList.GetAllUserAsync();

            //Assert
            Assert.Equal(json, newUserTest.Content);
        }

        [Fact]
        public void AccountRegisterationTest()
        {
            //Arrange
           Account test = new Account(6, 13000, 4);

            //Act
            int actual = test.GetbankUserId();

            //Assert
            int expected = 4;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task AccountRegisterationTest_ValidAccount()
        {
            //Arrange
            Mock<IRepository> mockRepo = new();
            Account test = new Account(6, 13000, 6);
            List<Account> newAccount = new List<Account>();
            newAccount.Add(test);

            string json = JsonSerializer.Serialize(newAccount);
            Mock<ILogger<Project1.Api.Controllers.FrontController>> mocklog = new();

            mockRepo.Setup(x => x.GetAllAccounts()).ReturnsAsync(newAccount);
            var accountList = new Project1.Api.Controllers.FrontController(mockRepo.Object, mocklog.Object);

            //Act
            var newAccountTest = await accountList.GetAllAccountAsync();

            //Assert
            Assert.Equal(json, newAccountTest.Content);
        }
    }      
}