using Xunit;
using Project1.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Project1.DataLogic;

namespace Project1.ApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userRegister = new User();
            var bankUser = new User();

            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(Xunit => Xunit.RegisterUser(bankUser)).ReturnsAsync();
            {
            };

            var accountService = new User(bankUser.Object, null);

            IEnumerable<User> result = userRegister.RegisterUser("Libra");

            Assert.Equal(1, result.Count());
        }
    }

    public class UnitTest2
    {
        [Fact]
        public void Test2()
        {
            var accountRegister = new Account();
            var bankAccount = new Account();

            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(Xunit => Xunit.RegisterAccount(bankAccount)).ReturnsAsync();
            {
            };

            var accountService = new Account(bankAccount.Object, null);

            IEnumerable<Account> result = accountRegister.RegisterAccount(1);

            Assert.Equal(2, result.Count());
        }
    }
}