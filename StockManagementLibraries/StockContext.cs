using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementLibraries
{
    public class StockContext : DbContext
    {
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Laptop> Laptops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = StockDataBase"
                );
        }
    }
}
