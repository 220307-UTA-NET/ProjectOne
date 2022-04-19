using Xunit;
using Project1.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Project1.DataLogic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Project1.ApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllUsersTest()
        {
            /*var userRegister = new User();
            var bankUser = new User();

            Mock<IRepository> mockRepo = new();
            Mock<ILogger<API.Controllers.LoginController>> mocklog = new();
            User user1 = new User();
            string bankUserUsername = "Libra";
            mockRepo.Setup(Xunit => Xunit.GetAllUsers(bankUserUsername)).ReturnsAsync();
            var loginController = new API.Controllers.LoginController(mocklog.Object, mockRepo.Object);

            var accountService = new User(bankUser.Object, null);

            IEnumerable<User> actualResult = new List<User>() {user1};

            Assert.Equal(1, result.Count());*/
        }

        [Fact]
        public void GetAllAccountsTest()
        {
           /*var accountRegister = new Account();
            var bankAccount = new Account();

            Mock<IRepository> mockRepo = new();
            Mock<ILogger<API.Controllers.LoginController>> mocklog = new();
            Account account1 = new Account();
            int bankUserId = 1;
            mockRepo.Setup(Xunit => Xunit.GetAllAccounts(bankUserId)).ReturnsAsync();
            var loginController = new API.Controllers.FrontController(mocklog.Object, mockRepo.Object);

            var accountService = new Account(bankUser.Object, null);

            IEnumerable<Account> actualResult = new List<Account>() { account1 };

            Assert.Equal(1, result.Count());*/
        }
    }      
}