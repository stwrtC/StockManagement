using StockManagementLibraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using (StockContext context = new StockContext())
{
    context.Database.EnsureCreated();
}
namespace StockManagementLibraries.Repositories
{
    public class DbGPURepository : IStockRepository<GPU>
    {
        
        private List<GPU> _gpus;

        public DbGPURepository()
        {
            _gpus = new List<GPU>()
            {
                new GPU()
                {Name = "GTX 950", Brand = "Nvidia", Quantity = 5, Price = 209.99m, Vram = 2, Cuda = 768, ImageThumbnail = "https://www.bhphotovideo.com/images/images2500x2500/asus_mini_gtx950_2g_geforce_gtx_950_mini_1254107.jpg" },
                new GPU()
                {Name = "RTX 4090 Ti", Brand = "Nvidia", Quantity = 1, Price = 1699.99m, Vram = 24, Cuda = 16384, ImageThumbnail = "https://cdn.appuals.com/wp-content/uploads/2022/07/RTX_4090_Ti_Render-640x360-1.jpg" }
            };
            using var context = new StockContext();
            context.AddRange(_gpus);
            context.SaveChanges();
            
        }
        public GPU Add( GPU item)
        {
            using var context = new StockContext();
            context.GPUs.Add(item);
            context.SaveChanges();
            return GetById(item.Id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _gpus.Remove(item);
            }
        }

        public IEnumerable<GPU> GetAll()
        {
            using var context = new StockContext();
            var gpus = context.GPUs.ToList();
            return gpus;
        }

        public GPU? GetById(int id)
        {
            return _gpus.FirstOrDefault(x => x.Id == id);
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

                return item;

            }
            return null;
        }
    }
}