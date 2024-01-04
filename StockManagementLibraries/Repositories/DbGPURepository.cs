using StockManagementLibraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementLibraries.Repositories
{
    public class DbGPURepository : IStockRepository<GPU>
    {

        private readonly StockContext context;

        public DbGPURepository(StockContext _context)
        {
            context = _context;
        }

        public GPU Add( GPU item)
        {
            context.GPUs.Add(item);
            context.SaveChanges();
            return GetById(item.Id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.GPUs.Remove(item);
                context.SaveChanges();
            }
        }

        public IEnumerable<GPU> GetAll()
        {
            var gpus = context.GPUs.ToList();
            return gpus;
        }

        public GPU? GetById(int id)
        {
            return context.GPUs.FirstOrDefault(x=>x.Id == id);
        }


        public GPU? Update(GPU gpu)
        {
            var item = GetById(gpu.Id);
            if (item != null)
            {
                item.Name = gpu.Name;
                item.Brand = gpu.Brand;
                item.Description = gpu.Description;
                item.Quantity = gpu.Quantity;
                item.Price = gpu.Price;
                item.Vram = gpu.Vram;
                item.Cuda = gpu.Cuda;

                context.GPUs.Update(item);
                context.SaveChanges();
                return item;

            }
            return null;
        }
    }
}