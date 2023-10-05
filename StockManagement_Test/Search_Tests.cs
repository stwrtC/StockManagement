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
    public class Search_Tests
    {
        private static Mock<LaptopRepository> mockLaptopRepo;
        private static Mock<GPURepository> mockGPURepo;

        [SetUp]
        public void SetUp()
        {
            mockLaptopRepo = new Mock<LaptopRepository>();
            mockGPURepo = new Mock<GPURepository>();
        }
        [Test]
        public void GetType()
        {
            // Arrange
            Search search = new Search(mockGPURepo.Object, mockLaptopRepo.Object);
            Laptop newLaptop = (new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 });
            var testID = mockLaptopRepo.Object.Add(newLaptop).Id;
            // Act
            string result = search.GetType(testID);
            string expected = "Laptop";
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
