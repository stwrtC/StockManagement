using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class GPURepository : IStockRepository<GPU>
    {
        private List<GPU> _gpus;

        public GPURepository()
        {
            _gpus = new List<GPU>()
            {
                new GPU() 
                {Name = "Nvidia GTX 950", Quantity = 5, Price = 209.99m, Vram = 2, Cuda = 768 },
                new GPU()
                {Name = "Nvidia RTX 4090 Ti", Quantity = 1, Price = 1699.99m, Vram = 24, Cuda = 16384 }
            };
            
        }
        public GPU Add( GPU item)
        {
            _gpus.Add(item);
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
            return _gpus;
        }

        public GPU? GetById(int id)
        {
            return _gpus.FirstOrDefault(x => x.Id == id);
        }


        public GPU? Update(int id, GPU newStock)
        {
            var item = GetById(id);
            if (item != null)
            {
                item.Name = newStock.Name;
                item.Quantity = newStock.Quantity;
                item.Price = newStock.Price;
                item.Vram = newStock.Vram;
                item.Cuda = newStock.Cuda;

                return item;

            }
            return null;
        }
    }
}