using Moq;
using StockManagement.Services;
using StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Test
{
    internal class LaptopCalc_Tests
    {
        [Test]
        public void TotalStockTest()
        {
            // Arrange
            var mockLaptopRepo = new Mock<LaptopRepository>();
            var laptopCalc = new LaptopCalc(mockLaptopRepo.Object);
            // Act
            int result = laptopCalc.TotalStock();
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void TotalValueTest()
        {
            // Arrange
            var mockLaptopRepo = new Mock<LaptopRepository>();
            var laptopCalc = new LaptopCalc(mockLaptopRepo.Object);
            // Act
            var result = laptopCalc.TotalValue();
            // Assert
            Assert.That(result, Is.EqualTo(199));
        }
    }
}
