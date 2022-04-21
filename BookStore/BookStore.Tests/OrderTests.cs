using System;
using Xunit;
using System.Collections.Generic;
using BookStore.Domain;

namespace BookStore.Tests
{
    public class OrderTests
    {
        private Order o;
        private int testCustomerID = 1;
        private int testLocationID = 2;
        private decimal testProductPrice = 10.99M;
        private int testAmount = 4;
        private static Product p1 = new Product(1, "The Lord of the Rings: The Fellowship of the Ring", 10.99M);
        private static Product p2 = new Product(2, "The Lord of the Rings: The Two Towers", 10.99M);
        private static Product p3 = new Product(3, "The Lord of the Rings: The Return of the King", 10.99M);


        public OrderTests()
        {
            o = new Order(testCustomerID, testLocationID);

            o.SetItemAmount(p1, testAmount);
            o.SetItemAmount(p2, testAmount);
            o.SetItemAmount(p3, testAmount);
        }
        


        // test customer id
        [Fact]
        public void Order_TestGetCustomerID()
        {
            int c = o.CustomerID;
            Assert.Equal(testCustomerID, c);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Order_TestSetCustomerID(int newID)
        {
            o.CustomerID = newID;
            int c = o.CustomerID;
            Assert.Equal(newID, c);
        }



        // test location id
        [Fact]
        public void Order_TestGetLocationID()
        {
            int i = o.LocationID;
            Assert.Equal(testLocationID, i);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void Order_TestSetLocationID(int newID)
        {
            o.LocationID = newID;
            int i = o.LocationID;
            Assert.Equal(newID, i);
        }



        // test get item amount
        public static IEnumerable<object[]> SampleItems =>
            new List<object[]>
            {
                new object[] {p1},
                new object[] {p2},
                new object[] {p3}
            };

        [Theory]
        [MemberData(nameof(SampleItems))]
        public void Order_TestGetItemAmt_Object_Pass(Product p)
        {
            int i = o.GetItemAmount(p);
            Assert.Equal(testAmount, i);
        }

        [Fact]
        public void Order_TestGetItemAmt_Object_Fail()
        {
            int i = o.GetItemAmount(null);
            Assert.Equal(-1, i);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Order_TestGetItemAmt_ID_Pass(int productID)
        {
            int i = o.GetItemAmount(productID);
            Assert.Equal(testAmount, i);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(22)]
        public void Order_TestGetItemAmt_ID_Fail(int productID)
        {
            int i = o.GetItemAmount(productID);
            Assert.Equal(-1, i);
        }



        // test set item amount
        [Theory]
        [InlineData(2)]
        [InlineData(13)]
        [InlineData(0)]
        public void Order_TestSetItemAmt_Object_Pass(int amount)
        {
            bool done = o.SetItemAmount(p1, amount);
            Assert.True(done);

            int x = o.GetItemAmount(p1);
            Assert.Equal(amount, x);
        }

        public static IEnumerable<object[]> FailedItems =>
            new List<object[]>
            {
                new object[] {null, 2},
                new object[] {null, -1},
                new object[] {p1, -1}
            };

        [Theory]
        [MemberData(nameof(FailedItems))]
        public void Order_TestSetItemAmt_Object_Fail(Product p, int amount)
        {
            bool done = o.SetItemAmount(p, amount);
            Assert.False(done);
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 0)]
        [InlineData(3, 11)]
        public void Order_TestSetItemAmt_ID_Pass(int productID, int amount)
        {
            bool done = o.SetItemAmount(productID, amount);
            Assert.True(done);

            int x = o.GetItemAmount(productID);
            Assert.Equal(amount, x);
        }

        [Theory]
        [InlineData(-1, 3)]
        [InlineData(2, -1)]
        [InlineData(-1, -1)]
        public void Order_TestSetItemAmt_ID_Fail(int productID, int amount)
        {
            bool done = o.SetItemAmount(productID, amount);
            Assert.False(done);
        }



        // test remove item
        public static IEnumerable<object[]> RemoveObjectPass =>
            new List<object[]>
            {
                new object[] {p1},
                new object[] {p2},
                new object[] {p3}
            };
        
        [Theory]
        [MemberData(nameof(RemoveObjectPass))]
        public void Order_TestRemoveItem_Object_Pass(Product p)
        {
            bool done = o.RemoveItem(p);
            Assert.True(done);

            int i = o.GetItemAmount(p);
            Assert.Equal(-1, i);
        }

        [Fact]
        public void Order_TestRemoveItem_Object_Fail()
        {
            bool done = o.RemoveItem(null);
            Assert.False(done);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Order_TestRemoveItem_ID_Pass(int productID)
        {
            bool done = o.RemoveItem(productID);
            Assert.True(done);

            int i = o.GetItemAmount(productID);
            Assert.Equal(-1, i);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(6)]
        public void Order_TestRemoveItem_ID_Fail(int productID)
        {
            bool done = o.RemoveItem(productID);
            Assert.False(done);
        }

        // test price
        [Fact]
        public void Order_TestGetTotal()
        {
            decimal expected = testProductPrice * testAmount * 3;
            decimal t = o.Total;
            Assert.Equal(expected, t);
        }

        // test time
        [Fact]
        public void Order_TestTime()
        {
            DateTimeOffset d = DateTimeOffset.Now;
            o.Time = d;
            Assert.Equal(d, o.Time);
        }
    }
}