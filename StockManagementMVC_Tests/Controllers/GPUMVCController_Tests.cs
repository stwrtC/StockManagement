using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StockManagementLibraries.Models;
using StockManagementLibraries.Test_Helper;
using StockManagementMVC.ViewModels;
using System.Reflection;

namespace StockManagementMVC_Tests
{
    public class GPUMVCController_Tests
    {
        private static Mock<IStockRepository<GPU>> repository;
        private static Mock<ILogger<GPUController>> logger;
        private static GetObjectResult helper;





        [SetUp]
        public void Setup()
        {
            repository = new Mock<IStockRepository<GPU>>();
            logger = new Mock<ILogger<GPUController>>();
            helper = new GetObjectResult();

        }

        [Test]
        public void List_Test()
        {
            // Arrange
            var controller = new GPUController(repository.Object, logger.Object);
            var GPUs = new List<GPU>() { new GPU() { Id = 1 } };
            repository.Setup(x => x.GetAll()).Returns(GPUs);
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
        public void AddGPU()
        {
            var controller = new GPUController(repository.Object, logger.Object);
            GPU newGPU = new GPU() { Id = 2, Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            repository.Setup(x => x.Add(newGPU)).Returns(newGPU);
            repository.Setup(x => x.GetById(2)).Returns(newGPU);
            // Act
            var result = controller.Create(newGPU);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result , Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public void DeleteGPU()
        {
            var controller = new GPUController(repository.Object, logger.Object);
            GPU newGPU = new GPU() { Id = 2, Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            repository.Setup(x => x.Add(newGPU)).Returns(newGPU);

            repository.Setup(x => x.Delete(newGPU.Id));
            repository.Setup(x => x.GetById(newGPU.Id)).Returns(newGPU);

            var result = controller.Delete(newGPU.Id);

            //repository.Verify(x => x.Delete(newGPU.Id), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void UpdateGPU()
        {
            var controller = new GPUController(repository.Object, logger.Object);
            GPU oldGPU = new GPU() { Id = 2, Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            GPU newGPU = new GPU() { Id = 2, Name = "Nvidia GTX 1080 v2", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };

            repository.Setup(x => x.Update(newGPU));
            repository.Setup(x => x.GetById(newGPU.Id)).Returns(newGPU);



            var result = controller.Update(oldGPU.Id);

            repository.Verify(x=>x.Update(newGPU), Times.Once);
            Assert.That(result, Is.Not.Null);

        }
        [Test]
        public void GetDetails()
        {
            // Arrange
            var controller = new GPUController(repository.Object, logger.Object);
            GPU item = new GPU() { Id = 1 };
            var GPUs = new List<GPU>() { item };
            repository.Setup(x => x.GetAll()).Returns(GPUs);
            repository.Setup(x => x.GetById(1)).Returns(item);
            // Act
            var result = controller.Details(item.Id);
            // Assert            
            repository.Verify(x=> x.GetById(1), Times.Once);
            Assert.That(result, Is.Not.Null);
        }

    }
}