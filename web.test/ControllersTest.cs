using Xunit;
using Moq;
using web.api.Controllers;
using web.db.Models;
using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;



namespace web.test;

public class ControllersTest
{
    [Fact]
    public void HttpGetTest()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(repo => repo.Products).Returns(new List<Product>
        {
            new Product { ProductID = 1, Name = "P1", Description = "D1", Price = 1.11m, Quantity = 11, Category = "C1" },
            new Product { ProductID = 2, Name = "P2", Description = "D2", Price = 2.22m, Quantity = 22, Category = "C2" },
            new Product { ProductID = 3, Name = "P3", Description = "D3", Price = 3.33m, Quantity = 33, Category = "C3" }
        });
        var controller = new ProductsController(mockRepo.Object);

        // Act
        Product result = controller.Get(2);
        IEnumerable<Product> resultList = controller.Get();
        int counter = 0;
        foreach (Product p in resultList)
        {
            counter++;
        }

        // Assert
        // var okResult = Assert.IsType<OkObjectResult>(result);
        // var products = Assert.IsType<List<Product>>(okResult.Value);
        Assert.Equal(2, result.ProductID);
        Assert.Equal("P2", result.Name);
        Assert.Equal(3, counter);
    }

    [Fact]
    public void HttpDeleteTest()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(repo => repo.Products).Returns(new List<Product>
        {
            new Product { ProductID = 1, Name = "P1", Description = "D1", Price = 1.11m, Quantity = 11, Category = "C1" },
            new Product { ProductID = 2, Name = "P2", Description = "D2", Price = 2.22m, Quantity = 22, Category = "C2" },
            new Product { ProductID = 3, Name = "P3", Description = "D3", Price = 3.33m, Quantity = 33, Category = "C3" }
        });
        var controller = new ProductsController(mockRepo.Object);

        // Act
        controller.Delete(2);

        // Assert
        mockRepo.Verify(repo => repo.DeleteProduct(It.IsAny<Product>()), Times.Once);
    }
    [Fact]
    public void HttpPutTest()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(repo => repo.Products).Returns(new List<Product>
        {
            new Product { ProductID = 1, Name = "P1", Description = "D1", Price = 1.11m, Quantity = 11, Category = "C1" },
            new Product { ProductID = 2, Name = "P2", Description = "D2", Price = 2.22m, Quantity = 22, Category = "C2" },
            new Product { ProductID = 3, Name = "P3", Description = "D3", Price = 3.33m, Quantity = 33, Category = "C3" }
        });
        var controller = new ProductsController(mockRepo.Object);

        // Act
        controller.Put(2, new Product { ProductID = 2, Name = "P2", Description = "D2", Price = 42.22m, Quantity = 32, Category = "C2" });

        // Assert
        mockRepo.Verify(repo => repo.UpdateProduct(It.IsAny<Product>()), Times.Once);
    }
}