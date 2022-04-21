using System;
using System.Collections.Generic;
using Xunit;
using BookStore.Domain;

namespace BookStore.Tests
{
    public class LocationTests
    {
        private Location l;
        private string testName = "Downtown";
        private int testAmount = 4;
        private static Product p1 = new Product(1, "The Lord of the Rings: The Fellowship of the Ring", 10.99M);
        private static Product p2 = new Product(2, "The Lord of the Rings: The Two Towers", 10.99M);
        private static Product p3 = new Product(3, "The Lord of the Rings: The Return of the King", 10.99M);

        public LocationTests()
        {
            l = new Location(testName);

            l.SetProductAmount(p1, testAmount);
            l.SetProductAmount(p2, testAmount);
            l.SetProductAmount(p3, testAmount);
        }
        
        ////// test name
        [Fact]
        public void Location_TestGetName()
        {
            string n = l.Name;
            Assert.Equal(testName, n);
        }

        [Theory]
        [InlineData("Uptown")]
        public void Location_TestSetName(string newName)
        {
            l.Name = newName;
            string n = l.Name;
            Assert.Equal(newName, n);
        }



        ////// test get product amt
        public static IEnumerable<object[]> SampleProducts =>
            new List<object[]>
            {
                new object[] {p1},
                new object[] {p2},
                new object[] {p3}
            };

        [Theory]
        [MemberData(nameof(SampleProducts))]
        public void Location_TestGetProductAmt_Object_Pass(Product p)
        {
            int i = l.GetProductAmount(p);
            Assert.Equal(testAmount, i);
        }

        [Fact]
        public void Location_TestGetProductAmt_Object_Fail()
        {
            int i = l.GetProductAmount(null);
            Assert.Equal(-1, i);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Location_TestGetProductAmt_ID_Pass(int productID)
        {
            int i = l.GetProductAmount(productID);
            Assert.Equal(testAmount, i);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(22)]
        public void Location_TestGetProductAmt_ID_Fail(int productID)
        {
            int i = l.GetProductAmount(productID);
            Assert.Equal(-1, i);
        }



        ////// test set product amt
        [Theory]
        [InlineData(5)]
        [InlineData(20)]
        [InlineData(0)]
        public void Location_TestSetProductAmt_Object_Pass(int amount)
        {
            bool done = l.SetProductAmount(p1, amount);
            Assert.True(done);

            int x = l.GetProductAmount(p1);
            Assert.Equal(amount, x);
        }


        public static IEnumerable<object[]> FailedProducts =>
            new List<object[]>
            {
                new object[] {null, 2},
                new object[] {null, -1},
                new object[] {p1, -1}
            };
        
        [Theory]
        [MemberData(nameof(FailedProducts))]
        public void Location_TestSetProductAmt_Object_Fail(Product p, int amount)
        {
            bool done = l.SetProductAmount(p, amount);
            Assert.False(done);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 0)]
        [InlineData(3, 30)]
        public void Location_TestSetProductAmt_ID_Pass(int productID, int amount)
        {
            bool done = l.SetProductAmount(productID, amount);
            Assert.True(done);

            int x = l.GetProductAmount(productID);
            Assert.Equal(amount, x);
        }

        [Theory]
        [InlineData(-1, 3)]
        [InlineData(2, -1)]
        [InlineData(-1, -1)]
        public void Location_TestSetProductAmt_ID_Fail(int productID, int amount)
        {
            bool done = l.SetProductAmount(productID, amount);
            Assert.False(done);
        }




        ////// test withdraw product amt
        public static IEnumerable<object[]> WithdrawObjectPass =>
            new List<object[]>
            {
                new object[] {p1, 1},
                new object[] {p2, 3},
                new object[] {p3, 4}
            };
        [Theory]
        [MemberData(nameof(WithdrawObjectPass))]
        public void Location_TestWithdrawProduct_Object_Pass(Product p, int amount)
        {
            bool done = l.WithdrawProduct(p, amount);
            Assert.True(done);
        }

        public static IEnumerable<object[]> WithdrawObjectFail =>
            new List<object[]>
            {
                new object[] {null, 1},
                new object[] {p2, 0},
                new object[] {p3, 9}
            };

        [Theory]
        [MemberData(nameof(WithdrawObjectFail))]
        public void Location_TestWithdrawProduct_Object_Fail(Product p, int amount)
        {
            bool done = l.WithdrawProduct(p, amount);
            Assert.False(done);
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        public void Location_TestWithdrawProduct_ID_Pass(int productID, int amount)
        {
            bool done = l.WithdrawProduct(productID, amount);
            Assert.True(done);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(2, 10)]
        public void Location_TestWithdrawProduct_ID_Fail(int productID, int amount)
        {
            bool done = l.WithdrawProduct(productID, amount);
            Assert.False(done);
        }

        


        ////// test remove product
        public static IEnumerable<object[]> RemoveObjectPass =>
            new List<object[]>
            {
                new object[] {p1},
                new object[] {p2},
                new object[] {p3}
            };

        [Theory]
        [MemberData(nameof(RemoveObjectPass))]
        public void Location_TestRemoveProduct_Object_Pass(Product p)
        {
            bool done = l.RemoveProduct(p);
            Assert.True(done);

            int i = l.GetProductAmount(p);
            Assert.Equal(-1, i);
        }

        [Theory]
        [InlineData(null)]
        public void Location_TestRemoveProduct_Object_Fail(Product p)
        {
            bool done = l.RemoveProduct(p);
            Assert.False(done);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Location_TestRemoveProduct_ID_Pass(int productID)
        {
            bool done = l.RemoveProduct(productID);
            Assert.True(done);

            int i = l.GetProductAmount(productID);
            Assert.Equal(-1, i);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(6)]
        public void Location_TestRemoveProduct_ID_Fail(int productID)
        {
            bool done = l.RemoveProduct(productID);
            Assert.False(done);
        }
    }
}