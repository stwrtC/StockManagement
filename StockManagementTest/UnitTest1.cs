using NUnit.Framework;
using StockManagement;
namespace StockManagementTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StockAdd()
        {
            List<Stock> stocks = new List<Stock>();
            stocks.Add(new Stock("Chromebook", "Laptop", 5, 199));


        }
        [Test] 
        public void StockRemove() 
        {
            List<Stock> stocks = new List<Stock>();
            stocks.Add(new Stock("Chromebook", "Laptop", 5, 199));
            stocks.Add(new Stock("Nvidia GTX 950", "GPU", 5, 209.99m));

            

        }
        [Test]
        public void LaptopStock() 
        {
            List<Stock> stocks = new List<Stock>();
            stocks.Add(new Stock("Chromebook", "Laptop", 5, 199));
            stocks.Add(new Stock("Nvidia GTX 950", "GPU", 5, 209.99m));
            var calc = new CalculateStock();
            Assert.That(calc.CalcLaptop(stocks), Is.EqualTo(5));
        }
        [Test]
        public void GPUStock()
        {
            List<Stock> stocks = new List<Stock>();
            stocks.Add(new Stock("Chromebook", "Laptop", 5, 199));
            stocks.Add(new Stock("Nvidia GTX 950", "GPU", 5, 209.99m));
            var calc = new CalculateStock();
            Assert.That(calc.CalcGPU(stocks), Is.EqualTo(5));
        }

    }
}