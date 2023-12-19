using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementLibraries.Models;

namespace StockManagementLibraries
{
    public class StockContext : DbContext
    {
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Laptop> Laptops { get; set; }

        public StockContext()
        {

        }
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = StockDataBase");
            }
        }
    }
}
