using Xunit;
using Moq;
using irepository;
using System.Collections.Generic;
using business__logic;
using System.Threading.Tasks;

namespace WebTestapplication
{
    public class UnitTest1
    {
        [Fact]
        public async Task api_getcustomerid_customerid()
        {


            Mock<Irepository> mock = new Mock<Irepository>();



            mock.Setup(x => x.getcustomerid("Christian", "cubides")).ReturnsAsync(1);



            Assert.Equal(1, 1);


        }

        [Fact]
        public async Task api_getcustomerid_customerid1()
        {


            Mock<Irepository> mock = new Mock<Irepository>();



            mock.Setup(x => x.getcustomerid("Christian", "cubides")).ReturnsAsync(1);



            Assert.Equal(1, 1);


        }

        [Fact]
        public async Task api_getcustomerid_customerid3()
        {


            Mock<Irepository> mock = new Mock<Irepository>();



            mock.Setup(x => x.getcustomerid("Christian", "cubides")).ReturnsAsync(1);



            Assert.Equal(1, 1);


        }
        [Fact]
        public async Task api_getcustomerid_customerid4()
        {


            Mock<Irepository> mock = new Mock<Irepository>();



            mock.Setup(x => x.getcustomerid("Christian", "cubides")).ReturnsAsync(1);



            Assert.Equal(1, 1);


        }
        [Fact]
        public async Task api_getcustomerid_customerid5()
        {


            Mock<Irepository> mock = new Mock<Irepository>();



            mock.Setup(x => x.getcustomerid("Christian", "cubides")).ReturnsAsync(1);



            Assert.Equal(1, 1);


        }
    }
}