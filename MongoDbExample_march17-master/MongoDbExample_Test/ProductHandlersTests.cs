using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Commands;
using MongoDbExample.Controllers;
using MongoDbExample.Handlers;
using MongoDbExample.Models;
using MongoDbExample.Queries;
using Moq;

namespace MongoDbExample_Test
{

    public class ProductsControllerTests
    {
        private readonly List<Products> _mockProducts = new List<Products>
        {
            new Products { id = "1", name = "TonyTv", category = "electric", price = 59000 }
        };

        [Fact]
        public async void Get_ReturnsAllProducts()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetProductsQuery>(), default)).ReturnsAsync(_mockProducts);

            var controller = new ProductsController(mediatorMock.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.Equal(_mockProducts, result);
        }

        [Fact]
        public async void GetById_ReturnsProduct()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var productId = "1";

            mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default)).ReturnsAsync(_mockProducts[0]);

            var controller = new ProductsController(mediatorMock.Object);

            // Act
            var result = await controller.Get(productId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Products>>(result);
            var product = Assert.IsType<Products>(actionResult.Value);
            Assert.Equal(_mockProducts[0], product);
        }

       
    }
}






     


      
    