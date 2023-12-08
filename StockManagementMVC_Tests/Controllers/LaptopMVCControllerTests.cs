using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StockManagementLibraries.Models;
using StockManagementLibraries.Test_Helper;
using StockManagementMVC.ViewModels;
using System.Reflection;

namespace StockManagementMVC_Tests
{
    public class LaptopMVCControllerTests
    {
        private static Mock<IStockRepository<Laptop>> repository;
        private static Mock<ILogger<LaptopController>> logger;
        private static GetObjectResult helper;





        [SetUp]
        public void Setup()
        {
            repository = new Mock<IStockRepository<Laptop>>();
            logger = new Mock<ILogger<LaptopController>>();
            helper = new GetObjectResult();

        }

        [Test]
        public void List_Test()
        {
            // Arrange
            var controller = new LaptopController(repository.Object, logger.Object);
            var laptops = new List<Laptop>() { new Laptop() { Id = 1 } };
            repository.Setup(x => x.GetAll()).Returns(laptops);
            // Act
            var result = controller.List();
            var modelResult = result.Model;
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.TypeOf<ViewResult>());
                Assert.That(modelResult, Is.Not.Null);
            });          

        }

        [Test]
        public void AddLaptop()
        {
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop newLaptop = new Laptop() { Id = 2, Name = "Macbook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            repository.Setup(x => x.Add(newLaptop)).Returns(newLaptop);
            repository.Setup(x => x.GetById(2)).Returns(newLaptop);
            // Act
            var result = controller.Create(newLaptop);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result , Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public void DeleteLaptop()
        {
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop newLaptop = new Laptop() { Id = 2, Name = "Macbook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            repository.Setup(x => x.Add(newLaptop)).Returns(newLaptop);

            repository.Setup(x => x.Delete(newLaptop.Id));
            repository.Setup(x => x.GetById(newLaptop.Id)).Returns(newLaptop);

            var result = controller.Delete(newLaptop.Id);

            //repository.Verify(x => x.Delete(newLaptop.Id), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void UpdateLaptop()
        {
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop oldLaptop = new Laptop() { Id = 2, Name = "Macbook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            Laptop newLaptop = new Laptop() { Name = "Macbook2", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };

            repository.Setup(x => x.Update(newLaptop));
            repository.Setup(x => x.GetById(newLaptop.Id)).Returns(newLaptop);



            var result = controller.Update(oldLaptop.Id);

            repository.Verify(x=>x.Update(newLaptop), Times.Once);
            Assert.That(result, Is.Not.Null);

        }
        [Test]
        public void GetDetails()
        {
            // Arrange
            var controller = new LaptopController(repository.Object, logger.Object);
            Laptop item = new Laptop() { Id = 1 };
            var laptops = new List<Laptop>() { item };
            repository.Setup(x => x.GetAll()).Returns(laptops);
            repository.Setup(x => x.GetById(1)).Returns(item);
            // Act
            var result = controller.Details(item.Id);
            // Assert            
            repository.Verify(x=> x.GetById(1), Times.Once);
            Assert.That(result, Is.Not.Null);
        }

    }
}