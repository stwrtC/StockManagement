using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class GPURepository : IRepository<GPU>
    {
        private List<GPU> gpus;

        public GPURepository()
        {
            gpus = new List<GPU>();
        }
        public List<GPU> getGPUs() 
        {
            return gpus;
        }
        public GPU Add( GPU? item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            gpus.Add(item);
            return GetById(item.Id);
        }

        public void Delete( int? id)
        {
            var item = GetById( id);
            if (item != null)
            {
                gpus.Remove(item);
            }
        }

        public List<GPU> GetAll()
        {
            return gpus;
        }

        public GPU? GetById( int? id)
        {
            return gpus.FirstOrDefault(x => x.Id == id);
        }


        public GPU Update(int? id, GPU newStock)
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