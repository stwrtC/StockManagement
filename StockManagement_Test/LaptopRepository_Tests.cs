using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test
{
    public class LaptopRepository_Tests
    {
        // Create
        [Test]
        public void AddLaptop()
        {
            // Arrange
            var mockLaptopRepo = new Mock<LaptopRepository>();
            Laptop newLaptop = new Laptop() { Name = "Macbook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            // Act
            mockLaptopRepo.Object.Add(newLaptop);
            // Assert
            Assert.That(mockLaptopRepo.Object.GetAll(), Does.Contain(newLaptop));
        }

        // Read
        [Test]
        public void ReadLaptop()
        {
            // Arrange
            var mockLaptopRepo = new Mock<LaptopRepository>();
            // Act
            var result = mockLaptopRepo.Object.GetAll();
            // Assert
            Assert.That(result, Is.Not.Null);
        }

        // Update
        [Test]
        public void Update()
        {
            // Arrange
            var mockLaptopRepo = new Mock<LaptopRepository>();
            Laptop newLaptop = new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            var newId = mockLaptopRepo.Object.Add(newLaptop);
            Laptop updated = new Laptop() { Name = "Macbook", Quantity = 3, Price = 1999.99m, ScreenSize = 17, Ram = 32, Storage = 1024 };
            // Act
            var result = mockLaptopRepo.Object.Update(newId);
            // Assert
            Assert.That(result.Id, Is.EqualTo(newId.Id));
        }

        // Delete
        [Test]
        public void Delete()
        {
            // Arrange
            var mockLaptopRepo = new Mock<LaptopRepository>();
            Laptop newLaptop = new Laptop() { Name = "Macbook", Quantity = 3, Price = 1999.99m, ScreenSize = 17, Ram = 32, Storage = 512 };
            var newId = mockLaptopRepo.Object.Add(newLaptop).Id;
            // Act
            mockLaptopRepo.Object.Delete(newId);
            // Assert
            Assert.That(mockLaptopRepo.Object.GetAll().Any(x => x.Id != newId));
        }

    }
}
