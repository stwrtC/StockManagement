using Moq;
using StockManagement.Services;
using StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement_Test.Search_Tests
{
    public class SearchTests
    {
        private static Mock<IStockRepository<Laptop>> mockLaptopRepo;
        private static Mock<IStockRepository<GPU>> mockGPURepo;

        [SetUp]
        public void SetUp()
        {
            mockLaptopRepo = new Mock<IStockRepository<Laptop>>();
            mockGPURepo = new Mock<IStockRepository<GPU>>();
        }
        [Test]
        public void GetType()
        {
            // Arrange
            Search search = new Search(mockGPURepo.Object, mockLaptopRepo.Object);
            Laptop newLaptop = new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            mockLaptopRepo.Setup(x => x.GetById(newLaptop.Id)).Returns(newLaptop);
            // Act
            string result = search.GetType(newLaptop.Id);
            string expected = "Laptop";
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
