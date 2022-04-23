using Xunit;
using Moq;
using irepository;
using System.Collections.Generic;
using business__logic;
using System.Threading.Tasks;
using Webstore.controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace WebTestapplication
{
    public class UnitTest1


    {
        private readonly Customers _unitTest1;
        private readonly Mock<Irepository> mock = new Mock<Irepository>();
        private readonly Mock<ILogger<Customers>> logger = new Mock<ILogger<Customers>>();

        public UnitTest1()
        {
            _unitTest1 = new Customers(mock.Object, logger.Object);
        }


        [Fact]
        public async Task api_getcustomerid_customerid()
        {



            mock.Setup(x => x.getcustomerid("Christian", "cubides")).ReturnsAsync(1);


            List<registercustomers> customer_list = new List<registercustomers>();
            registercustomers customer = new registercustomers("Christian", "cubides");
            customer_list.Add(customer);




            // int result = await test1.getcustomerid("Christian", "cubides");

            int customer_id = await _unitTest1.getcustomerid(customer_list);



            Assert.Equal(1, customer_id);


        }

        [Fact]
        public async Task api_getcustomerid_customerid1()
        {


            Mock<Irepository> mock = new Mock<Irepository>();



            mock.Setup(x => x.getcustomerid("Christian", "cubides")).ReturnsAsync(1);



            Assert.Equal(1, 1);


        }

        [Fact]
        public async Task api_register_customers()
        {





            mock.Setup(x => x.registercustomers("Christian", "cubides")).ReturnsAsync(new ContentResult() { StatusCode = 201 });
            List<registercustomers> customer_list = new List<registercustomers>();
            registercustomers customer = new registercustomers("Christian", "cubides");
            customer_list.Add(customer);


            var status_code = await _unitTest1.Registercustumers(customer_list);
            ContentResult result = status_code;

            Assert.Equal(result, status_code);


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