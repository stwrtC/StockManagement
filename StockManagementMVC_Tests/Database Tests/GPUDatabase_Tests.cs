using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using StockManagementLibraries.Models;
using StockManagementLibraries.Test_Helper;
using StockManagementMVC.ViewModels;
using System.Diagnostics;
using System.Reflection;

namespace StockManagementMVC_Tests.Database_Tests
{
    public class GPUDatabase_Tests
    {
        private static Mock<IStockRepository<GPU>> repository;
        private static Mock<ILogger<GPUController>> logger;
        private static GetObjectResult helper;
        private static DbContextOptionsBuilder<StockContext> builder;




        [SetUp]
        public void Setup()
        {
            repository = new Mock<IStockRepository<GPU>>();
            logger = new Mock<ILogger<GPUController>>();
            helper = new GetObjectResult();


            builder = new DbContextOptionsBuilder<StockContext>();
            builder.UseSqlServer(
            "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = StockTestData");

        }

        [Test]
        public void InsertIntoDataBase()
        {

            using (var context = new StockContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                GPU newGPU = new GPU() { Name = "GTX 1080", Brand = "Nvidia", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };

                context.GPUs.Add(newGPU);
                context.SaveChanges();

                Assert.That(context.GPUs, Does.Contain(newGPU));
            }
        }

        [Test]
        public void DeleteFromDataBase()
        {
            using (var context = new StockContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                GPU newGPU = new GPU() { Name = "GTX 1080", Brand = "Nvidia", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };

                context.GPUs.Add(newGPU);
                context.SaveChanges();

                context.GPUs.Remove(newGPU);
                context.SaveChanges();

                Assert.That(context.GPUs, Does.Not.Contain(newGPU));
            }
        }

        [Test]
        public void UpdateItem()
        {
            using (var context = new StockContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                GPU item = new GPU() { Name = "GTX 10", Brand = "Nvidia", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };

                context.GPUs.Add(item);
                context.SaveChanges();
                item.Name = "GTX 1080";
                item.Quantity = 5;
                context.GPUs.Update(item);
                context.SaveChanges();

                //Assert.That(context.GPUs, Does.Contain());
            }
        }


    }
}