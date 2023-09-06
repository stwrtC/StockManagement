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
            return GetById((int)item.Id);
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

        public int? GetIdByName(string? name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                GPU item = gpus.FirstOrDefault(x => x.Name == name);
                return item.Id;
            }
            return null;
        }

        public GPU Update( int? id, GPU newStock)
        {
            var item = GetById( id);
            if (item != null)
            {
                if (newStock.Name != null) { item.Name = newStock.Name; }
                if (newStock.Quantity.ToString() != null) { item.Quantity = newStock.Quantity; }
                if (newStock.Price.ToString() != null) { item.Price = newStock.Price; }
                if (newStock.Vram.ToString() != null) { item.Vram = newStock.Vram; }
                if (newStock.Cuda.ToString() != null) { item.Cuda = newStock.Cuda; }

                return item;

            }
            return null;

        }
    }
}