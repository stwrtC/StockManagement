using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test.Search_Tests.Search_Tests
{
    public class LaptopSearch_Tests
    {
        private static Mock<IStockRepository<Laptop>> mockLaptopRepo;

        [SetUp]
        public void SetUp()
        {
            mockLaptopRepo = new Mock<IStockRepository<Laptop>>();
        }
        [Test]
        public void GetIdByName()
        {
            // Arrange
            var searchLaptop = new SearchLaptop(mockLaptopRepo.Object);
            Laptop newLaptop = new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            mockLaptopRepo.Setup(x => x.GetAll()).Returns(new List<Laptop> { newLaptop });
            string name = "Chromebook";
            // Act
            List<int> result = searchLaptop.GetIdsByName(name);
            // Assert
            mockLaptopRepo.Verify(x => x.GetAll());
            Assert.That(result, Does.Contain(newLaptop.Id));
        }

        [Test]
        public void IDExists()
        {
            // Arrange
            var searchLaptop = new SearchLaptop(mockLaptopRepo.Object);
            Laptop newLaptop = new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            mockLaptopRepo.Setup(x => x.GetAll()).Returns(new List<Laptop> { newLaptop });
            // Act
            bool result = searchLaptop.IDExists(newLaptop.Id);
            // Assert
            mockLaptopRepo.Verify(x => x.GetAll());
            Assert.That(result, Is.EqualTo(true));

        }

    }
}
