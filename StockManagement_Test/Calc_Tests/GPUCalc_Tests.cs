using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test.Calc_Tests
{
    public class GPUCalc_Tests
    {
        private static Mock<IStockRepository<GPU>> mockGPURepo;

        [SetUp]
        public void SetUp()
        {
            mockGPURepo = new Mock<IStockRepository<GPU>>();
        }
        [Test]
        public void TotalStockTest()
        {
            // Arrange
            var gpuCalc = new GPUCalc(mockGPURepo.Object);
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080 FROM THE MOCK", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            mockGPURepo.Setup(x => x.GetAll()).Returns(new List<GPU> { newGPU });
            // Act
            int result = gpuCalc.TotalStock();
            // Assert
            mockGPURepo.Verify(x => x.GetAll());
            Assert.That(result, Is.EqualTo(newGPU.Quantity));
        }
        [Test]
        public void TotalValueTest()
        {
            // Arrange
            var gpuCalc = new GPUCalc(mockGPURepo.Object);
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080 FROM THE MOCK", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            mockGPURepo.Setup(x => x.GetAll()).Returns(new List<GPU> { newGPU });
            // Act
            var result = gpuCalc.TotalValue();
            // Assert
            mockGPURepo.Verify(x => x.GetAll());
            Assert.That(result, Is.EqualTo(newGPU.Price));
        }


    }
}
