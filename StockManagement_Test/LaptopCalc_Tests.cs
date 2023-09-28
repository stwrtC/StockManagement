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
            int expected = mockLaptopRepo.Object.GetAll().Select(x => x.Quantity).Sum();
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TotalValueTest()
        {
            // Arrange
            var mockLaptopRepo = new Mock<LaptopRepository>();
            var laptopCalc = new LaptopCalc(mockLaptopRepo.Object);
            // Act
            var result = laptopCalc.TotalValue();
            var expected = mockLaptopRepo.Object.GetAll().Select(x=>x.Price).Sum();
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
