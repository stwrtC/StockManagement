using Castle.Core.Internal;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StockManagement;
using StockManagement.API.Controllers;
using StockManagement.Services;
using StockManagementLibraries.Test_Helper;

namespace StockManagement_Test.Controller_Tests
{

    public class LaptopAPIController_Tests
    {
        private static GetObjectResult helper;
        private static Mock<IStockRepository<Laptop>> repository;
        private static Mock<ILogger<LaptopController>> logger;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IStockRepository<Laptop>>();
            helper =  new GetObjectResult();
            logger = new Mock<ILogger<LaptopController>>();
        }

        [Test]
        public void GetLaptop()
        {
            // Arrange
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop item = new Laptop() { Id = 1 };
            var laptops = new List<Laptop>() { item };
            repository.Setup(x => x.GetAll()).Returns(laptops);
            repository.Setup(x => x.GetById(1)).Returns(item);
            // Act
            var actionResult = controller.GetLaptop(item.Id);
            // Assert            
            var resultObject = helper.GetObjectResultContent(actionResult);
            Assert.That(resultObject.Id, Is.EqualTo(item.Id));
        }
        [Test]
        public void GetAll()
        {
            // Arrange
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop item = new Laptop() { Id = 1 };
            var laptops = new List<Laptop>() { item };
            repository.Setup(x => x.GetAll()).Returns(laptops);
            // Act
            var actionResult = controller.GetAll();


            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public void AddLaptop()
        {
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop newLaptop = new Laptop() { Id = 2, Name = "Macbook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            repository.Setup(x => x.Add(newLaptop)).Returns(newLaptop);
            repository.Setup(x => x.GetById(2)).Returns(newLaptop);
            // Act
            var actionResult = controller.Create(newLaptop);
            // Assert
            var resultObject = helper.GetObjectResultContent(actionResult);
            Assert.That(resultObject.Name, Is.EqualTo(newLaptop.Name));
        }

        // Delete
        [Test]
        public void Delete()
        {
            // Arrange
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop newLaptop = new Laptop() { Id = 1, Name = "Macbook", Quantity = 3, Price = 1999.99m, ScreenSize = 17, Ram = 32, Storage = 512 };
            repository.Setup(x => x.Delete(1));
            repository.Setup(x => x.GetById(1)).Returns(newLaptop);
            // Act
            var result = controller.Delete(1) as OkObjectResult;
            // Assert
            repository.Verify(x => x.Delete(1), Times.Once());
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

    }
}
