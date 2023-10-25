using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagement;
using StockManagement.API.Controllers;
using StockManagement.Services;

namespace StockManagement_Test.Controller_Tests
{

    public class GPUController_Tests
    {
        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
        private static Mock<IStockRepository<GPU>> repository;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IStockRepository<GPU>>();
        }

        [Test]
        public void GetLaptop()
        {
            // Arrange
            var controller = new GPUController(repository.Object);
            GPU item = new GPU() { Id = 1 };
            var laptops = new List<GPU>() { item };
            repository.Setup(x => x.GetAll()).Returns(laptops);
            repository.Setup(x => x.GetById(1)).Returns(item);
            // Act
            var actionResult = controller.GetGPU(item.Id);
            // Assert
            var resultObject = GetObjectResultContent(actionResult);
            Assert.That(resultObject.Id, Is.EqualTo(item.Id));
        }
        [Test]
        public void GetAll()
        {
            // Arrange
            var controller = new GPUController(repository.Object);
            GPU item = new GPU() { Id = 1 };
            var laptops = new List<GPU>() { item };
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
            var controller = new GPUController(repository.Object);
            GPU newGPU = new GPU() { Id = 2, Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            repository.Setup(x => x.Add(newGPU)).Returns(newGPU);
            repository.Setup(x => x.GetById(2)).Returns(newGPU);
            // Act
            var actionResult = controller.Create(newGPU);
            // Assert
            var resultObject = GetObjectResultContent(actionResult);
            Assert.That(resultObject.Name, Is.EqualTo(newGPU.Name));
        }

        // Delete
        [Test]
        public void Delete()
        {
            // Arrange
            var controller = new GPUController(repository.Object);
            GPU newGPU = new GPU() { Id = 1, Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            repository.Setup(x => x.Delete(1));
            repository.Setup(x => x.GetById(1)).Returns(newGPU);
            // Act
            controller.Delete(1);
            // Assert
            repository.Verify(x => x.Delete(1));
        }

    }
}
