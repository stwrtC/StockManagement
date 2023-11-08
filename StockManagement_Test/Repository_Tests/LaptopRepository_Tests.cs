using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test.Repository_Tests
{
    public class LaptopRepository_Tests
    {
        private static IStockRepository<Laptop> LaptopRepo;

        [SetUp]
        public void Setup()
        {
            LaptopRepo = new LaptopRepository();
        }
        // Create
        [Test]
        public void AddLaptop()
        {
            // Arrange
            Laptop newLaptop = new Laptop() { Name = "Macbook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            // Act
            LaptopRepo.Add(newLaptop);
            // Assert
            Assert.That(LaptopRepo.GetAll(), Does.Contain(newLaptop));
        }

        // Read
        [Test]
        public void ReadLaptop()
        {
            // Act
            var result = LaptopRepo.GetAll();
            // Assert
            Assert.That(result, Is.Not.Null);
        }

        // Update
        [Test]
        public void Update()
        {
            // Arrange
            Laptop newLaptop = new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            var newId = LaptopRepo.Add(newLaptop);
            Laptop updated = new Laptop() { Name = "Macbook", Quantity = 3, Price = 1999.99m, ScreenSize = 17, Ram = 32, Storage = 1024 };
            // Act
            var result = LaptopRepo.Update(newId);
            // Assert
            Assert.That(result.Id, Is.EqualTo(newId.Id));
        }

        // Delete
        [Test]
        public void Delete()
        {
            // Arrange
            Laptop newLaptop = new Laptop() { Name = "Macbook", Quantity = 3, Price = 1999.99m, ScreenSize = 17, Ram = 32, Storage = 512 };
            var newId = LaptopRepo.Add(newLaptop).Id;
            // Act
            LaptopRepo.Delete(newId);
            // Assert
            Assert.That(LaptopRepo.GetAll().Any(x => x.Id != newId));
        }

    }
}
