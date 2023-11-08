using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test.Search_Tests.Search_Tests
{
    public class GPUSearch_Tests
    {
        private static Mock<IStockRepository<GPU>> mockGPURepo;

        [SetUp]
        public void SetUp()
        {
            mockGPURepo = new Mock<IStockRepository<GPU>>();
        }
        [Test]
        public void GetIdByName()
        {
            // Arrange
            var searchGPU = new SearchGPU(mockGPURepo.Object);
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080 FROM THE MOCK", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            mockGPURepo.Setup(x => x.GetAll()).Returns(new List<GPU> { newGPU });
            string name = newGPU.Name;
            // Act
            List<int> result = searchGPU.GetIdsByName(name);
            // Assert
            mockGPURepo.Verify(x => x.GetAll());
            Assert.That(result, Does.Contain(newGPU.Id));
        }

        [Test]
        public void IDExists()
        {
            // Arrange
            var searchGPU = new SearchGPU(mockGPURepo.Object);
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            mockGPURepo.Setup(x => x.GetAll()).Returns(new List<GPU> { newGPU });
            // Act
            bool result = searchGPU.IDExists(newGPU.Id);
            // Assert
            Assert.That(result, Is.EqualTo(true));

        }


    }
}
