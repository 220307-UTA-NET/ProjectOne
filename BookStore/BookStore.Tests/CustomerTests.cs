using System;
using Xunit;
using BookStore.Domain;

namespace BookStore.Tests
{
    public class CustomerTests
    {
        private Customer c;
        private string testFirstName = "Scrooge";
        private string testLastName = "McDuck";
        private int testLocationID = 1;

        public CustomerTests()
        {
            c = new Customer(testFirstName, testLastName, testLocationID);
        }

        // test first name
        [Fact]
        public void Customer_TestGetFirstName()
        {
            string s = c.FirstName;
            Assert.Equal(testFirstName, s);
        }

        [Fact]
        public void Customer_TestSetFirstName()
        {
            string n = "David";
            c.FirstName = n;
            string s = c.FirstName;
            Assert.Equal(n, s);
        }

        // test last name
        [Fact]
        public void Customer_TestGetLastName()
        {
            string s = c.LastName;
            Assert.Equal(testLastName, s);
        }

        [Fact]
        public void Customer_TestSetLastName()
        {
            string n = "Rose";
            c.LastName = n;
            string s = c.LastName;
            Assert.Equal(n, s);
        }

        // test default location id
        [Fact]
        public void Customer_TestGetDefaultLocationID()
        {
            int i = c.DefaultLocationID;
            Assert.Equal(testLocationID, i);
        }

        [Fact]
        public void Customer_TestSetDefaultLocationID()
        {
            int j = 77;
            c.DefaultLocationID = j;
            int i = c.DefaultLocationID;
            Assert.Equal(j, i);
        }
    }
}
