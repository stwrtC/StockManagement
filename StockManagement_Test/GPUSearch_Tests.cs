using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test
{
    public class GPUSearch_Tests
    {
        private static Mock<GPURepository> mockGPURepo;

        [SetUp]
        public void SetUp()
        {
            mockGPURepo = new Mock<GPURepository>();
        }
        [Test]
        public void GetIdByName()
        {
            // Arrange
            var searchGPU = new SearchGPU(mockGPURepo.Object);
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            var newId = mockGPURepo.Object.Add(newGPU).Id;
            string name = newGPU.Name;
            // Act
            List<int> result = searchGPU.GetIdsByName(name);
            // Assert
            Assert.That(result, Does.Contain(newId));
        }

        [Test]
        public void IDExists()
        {
            // Arrange
            var searchGPU = new SearchGPU(mockGPURepo.Object);
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            var newId = mockGPURepo.Object.Add(newGPU).Id;
            // Act
            bool result = searchGPU.IDExists(newId);
            // Assert
            Assert.That(result, Is.EqualTo(true));

        }


    }
}
