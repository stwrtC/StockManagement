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
            // Assert
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void TotalValueTest()
        {
            // Arrange
            var mockGPURepo = new Mock<GPURepository>();
            var gpuCalc = new GPUCalc(mockGPURepo.Object);
            // Act
            var result = gpuCalc.TotalValue();
            // Assert
            Assert.That(result, Is.EqualTo(1909.98m));
        }


    }
}
