using NUnit.Framework;
using StockManagement;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace StockManagementTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StockAddGPU()
        {
            List<Stock> stock = new List<Stock>();
            Laptop newLaptop = new Laptop("Chromebook", 5, 199, 17, 32, 512);
            CRUD_Stock.AddItem(stock, newLaptop, null);
        }
        [Test]
        public void StockAddLaptop()
        {
            List<Stock> stock = new List<Stock>();
            GPU newGPU = new GPU("Nvidia RTX 4090 Ti", 1, 1699.99m, 24, 16384);
            CRUD_Stock.AddItem(stock, null, newGPU);
        }
        
        [Test]
        public void StockRemove()
        {
            List<Stock> stock = new List<Stock>();
            stock.Add(new Laptop("Chromebook", 5, 199, 17, 32, 512));
            stock.Add(new GPU("Nvidia GTX 950", 5, 209.99m, 2, 768));
            stock.Add(new GPU("Nvidia RTX 4090 Ti", 1, 1699.99m, 24, 16384));

            CRUD_Stock.DeleteItem(stock, 1);
        }
        [Test]
        public void LaptopStock() 
        {
            List<Stock> stock = new List<Stock>();
            stock.Add(new Laptop("Chromebook", 5, 199, 17, 32, 512));
            var calc = new CalculateStock();
            Assert.That(calc.CalcLaptop(stock), Is.EqualTo(5));
        }
        [Test]
        public void GPUStock()
        {
            List<Stock> stock = new List<Stock>();
            stock.Add(new GPU("Nvidia GTX 950", 5, 209.99m, 2, 768));
            stock.Add(new GPU("Nvidia RTX 4090 Ti", 1, 1699.99m, 24, 16384));
            var calc = new CalculateStock();
            Assert.That(calc.CalcGPU(stock), Is.EqualTo(6));
        }
    }
}