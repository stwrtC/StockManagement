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
    public class DbLaptopRepository_Tests
    {
        [Test]
        public void AddLaptop()
        {
            Laptop newlaptop = new() {Name = "Chromebook", Brand = "Samsung", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };

            var options = new DbContextOptionsBuilder<StockContext>()
                .UseInMemoryDatabase(databaseName: "TestStockDb")
                .Options;
            using (var context = new StockContext(options))
            {
                var repo = new DbLaptopRepository(context);
                repo.Add(newlaptop);
                var laptops = repo.GetAll();
                Assert.That(laptops, Does.Contain(newlaptop));
            }
        }

        [Test]
        public void GetAll()
        {

            var options = new DbContextOptionsBuilder<StockContext>().
                UseInMemoryDatabase(databaseName: "TestStockDb")
                .Options;
            using (var context = new StockContext(options))
            {
                var repo = new DbLaptopRepository(context);

                context.Laptops.Add( new Laptop {Name = "Chromebook",Brand ="Samsung", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 });
                context.Laptops.Add(new Laptop { Name = "Macbook",Brand = "Apple", Quantity = 3, Price = 1999.99m, ScreenSize = 17, Ram = 32, Storage = 1024 });

                context.SaveChanges();
                var laptops = repo.GetAll();

                Assert.That(laptops, Is.Not.Null);
                Assert.That(laptops.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void Update()
        {
            var options = new DbContextOptionsBuilder<StockContext>().
                UseInMemoryDatabase(databaseName: "TestStockDb")
                .Options;
            using (var context = new StockContext(options))
            {
                var repo = new DbLaptopRepository(context);
                Laptop item = new Laptop { Name = "Chromebook", Brand = "Samsung", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };

                context.Laptops.Add(item);
                context.SaveChanges();

                item.Price = 249;
                item.Quantity = 7;

                var updated = repo.Update(item);

                Assert.Multiple(() =>
                {
                    Assert.That(updated.Price, Is.EqualTo(249));
                    Assert.That(updated.Quantity, Is.EqualTo(7));
                });
            }
        }

        [Test]
        public void Delete()
        {
            var options = new DbContextOptionsBuilder<StockContext>().
                UseInMemoryDatabase(databaseName: "TestStockDb")
                .Options;
            using (var context = new StockContext(options))
            {
                var repo = new DbLaptopRepository(context);
                Laptop item = new Laptop {Name = "Chromebook", Brand = "Samsung", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };

                context.Laptops.Add(item);
                context.Laptops.Add(new Laptop {Name = "Macbook", Brand = "Apple", Quantity = 3, Price = 1999.99m, ScreenSize = 17, Ram = 32, Storage = 1024 });

                context.SaveChanges();

                repo.Delete(item.Id);
                var laptops = repo.GetAll();

                Assert.That(laptops, Does.Not.Contain(item));
            }
        }
    }
}
