using Xunit;
using Moq;
using RecipeBookApp.Api.Controllers;
using RecipeBookApp.BusinessLogic;
using RecipeBookApp.DataLogic;
using System.Threading.Tasks;
using System.IO;

namespace Api.Test
{
    public class UnitTest1
    {
        string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project0.txt");

        [Fact]
        public void User_CreateUserObject_ValidUser()
        {
            // typical naming convention
            // UnitOfTest_TestCondition_CorrectBehavior

            // Arrange 
            User test = new User("testuser", "testpass", "firsttest", "lasttest");

            // Act
            string? actual = test.Username;

            // Assert
            string ? expected = "testuser";
            Assert.Equal(expected, actual);
        }
    }
}