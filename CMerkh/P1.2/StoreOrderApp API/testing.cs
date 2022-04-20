using System;
using Xunit;
using Moq;
using StoreOrderApp;

namespace StoreOrderApp.Testing
{
    public class Tests
    {
        public void Test1(string[,] input1, int input2, string expected)
        {
            var actual = WordforTest.textCombine(input1, input2);
            Assert.Equal(expected, actual);
        }
    }
}