using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test
{
    public class GPUCalc_Tests
    {
        [Test]
        public void TotalStockTest()
        {
            // Arrange
            var mockGPURepo = new Mock<GPURepository>();
            var gpuCalc = new GPUCalc(mockGPURepo.Object);
            // Act
            int result = gpuCalc.TotalStock();
            int expected = mockGPURepo.Object.GetAll().Select(x=>x.Quantity).Sum();
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TotalValueTest()
        {
            // Arrange
            var mockGPURepo = new Mock<GPURepository>();
            var gpuCalc = new GPUCalc(mockGPURepo.Object);
            // Act
            var result = gpuCalc.TotalValue();
            var expected = mockGPURepo.Object.GetAll().Select(x => x.Price).Sum();
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


    }
}
