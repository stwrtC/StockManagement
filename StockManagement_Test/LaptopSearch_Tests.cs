using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test
{
    public class LaptopSearch_Tests
    {
        private static Mock<LaptopRepository> mockLaptopRepo;

        [SetUp]
        public void SetUp()
        {
            mockLaptopRepo = new Mock<LaptopRepository>();
        }
        [Test]
        public void GetIdByName()
        {
            // Arrange
            var searchLaptop = new SearchLaptop(mockLaptopRepo.Object);
            Laptop newLaptop = (new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 });
            var newId = mockLaptopRepo.Object.Add(newLaptop).Id;
            string name = "Chromebook";
            // Act
            List<int> result = searchLaptop.GetIdsByName(name);
            // Assert
            Assert.That(result, Does.Contain(newId));
        }

        [Test]
        public void IDExists()
        {
            // Arrange
            var searchLaptop = new SearchLaptop(mockLaptopRepo.Object);
            Laptop newLaptop = (new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 });
            var newId = mockLaptopRepo.Object.Add(newLaptop).Id;
            // Act
            bool result = searchLaptop.IDExists(newId);
            // Assert
            Assert.That(result, Is.EqualTo(true));

        }

    }
}
