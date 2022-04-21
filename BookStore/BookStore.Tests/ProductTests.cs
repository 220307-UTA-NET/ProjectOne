using System;
using Xunit;
using BookStore.Domain;

namespace BookStore.Tests
{
    public class ProductTests
    {
        int testID = 1;
        string testName = "Green Eggs & Ham";
        decimal testPrice = 4.99M;
        
        // test ID
        [Fact]
        public void Product_TestGetID()
        {
            Product p = new Product(testID, testName, testPrice);
            Assert.Equal(testID, p.ID);
        }

        [Theory]
        [InlineData(2)]
        public void Product_TestSetID(int newID)
        {
            Product p = new Product(testID, testName, testPrice);
            p.ID = newID;
            Assert.Equal(newID, p.ID);
        }
        
        // test name
        [Fact]
        public void Product_TestGetName()
        {
            Product p = new Product(testName, testPrice);
            Assert.Equal(testName, p.Name);
        }

        [Theory]
        [InlineData("Cat in the Hat")]
        public void Product_TestSetName(string newName)
        {
            Product p = new Product(testName, testPrice);
            p.Name = newName;
            Assert.Equal(newName, p.Name);
        }

        // test price
        [Fact]
        public void Product_TestGetPrice()
        {
            Product p = new Product(testName, testPrice);
            Assert.Equal(testPrice, p.Price);
        }

        [Theory]
        [InlineData(5.50)]
        public void Product_TestSetPrice(decimal newPrice)
        {
            Product p = new Product(testName, testPrice);
            p.Price = newPrice;
            Assert.Equal(newPrice, p.Price);
        }
    }
}