using Moq;
using StockManagement.Services;
using StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Test.Calc_Tests
{
    public class LaptopCalc_Tests
    {
        private static Mock<IStockRepository<Laptop>> mockLaptopRepo;

        [SetUp]
        public void SetUp()
        {
            mockLaptopRepo = new Mock<IStockRepository<Laptop>>();
        }
        [Test]
        public void TotalStockTest()
        {
            // Arrange
            var laptopCalc = new LaptopCalc(mockLaptopRepo.Object);
            Laptop newLaptop = new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            mockLaptopRepo.Setup(x => x.GetAll()).Returns(new List<Laptop> { newLaptop });
            // Act
            int result = laptopCalc.TotalStock();
            // Assert
            mockLaptopRepo.Verify(x => x.GetAll());
            Assert.That(result, Is.EqualTo(newLaptop.Quantity));
        }
        [Test]
        public void TotalValueTest()
        {
            // Arrange
            var laptopCalc = new LaptopCalc(mockLaptopRepo.Object);
            Laptop newLaptop = new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            mockLaptopRepo.Setup(x => x.GetAll()).Returns(new List<Laptop> { newLaptop });
            // Act
            var result = laptopCalc.TotalValue();
            // Assert
            mockLaptopRepo.Verify(x => x.GetAll());
            Assert.That(result, Is.EqualTo(newLaptop.Price));
        }
    }
}
