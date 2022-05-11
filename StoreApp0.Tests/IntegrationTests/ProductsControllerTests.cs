using System.Threading.Channels;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using StoreApp0.Api.Controllers;
using StoreApp0.Api.DTO;
using StoreApp0.BusinessLogic;
using StoreApp0.DataLogic;

namespace StoreApp0.Tests.IntegrationTests

{
    [TestClass]
    public class ProductsControllerTest
    {
        private readonly ProductController _productController;
        private readonly  IRepository _repository = Substitute.For<IRepository>();
        private readonly ILogger<ProductController> _logger = Substitute.For<ILogger<ProductController>>();


        public ProductsControllerTest()
        {
            _productController = new ProductController(_repository, _logger);
        }

        [TestMethod]
        public async Task ShouldReturnProduct_WhenValiIdpassed()
        {
            var product = new Product()
            {
                ProductId = 2,
                ProductName = "Test product name",
                ProductCatagory = "Test product catagory"

            };
        }



    }
}



