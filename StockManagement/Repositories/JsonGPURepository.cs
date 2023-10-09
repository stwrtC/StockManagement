using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Repositories
{
    public class JsonGPURepository : IStockRepository<GPU>
    {
        private readonly string filePath = @"C:\dev\StockManagement\StockManagement\JSON\GPUs.json";
        private List<GPU> _gpus;


        public JsonGPURepository() 
        {
            string fileContent = File.ReadAllText(filePath);
            _gpus = new List<GPU>();

            List<GPU> temp = JsonConvert.DeserializeObject<List<GPU>>(fileContent);
            foreach (GPU x in temp)
            {
                _gpus.Add(x);
            }
        }
        public GPU Add(GPU item)
        {
            _gpus.Add(item);
            string updatedJSon = JsonConvert.SerializeObject(_gpus, Formatting.Indented);
            File.WriteAllText(filePath, updatedJSon);
            return GetById(item.Id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                GPU itemToRemove = _gpus.Find(x => x.Id == id);
                _gpus.Remove(itemToRemove);
                string updatedJSon = JsonConvert.SerializeObject(_gpus, Formatting.Indented);
                File.WriteAllText(filePath, updatedJSon);
                _gpus.Remove(item);


            }
        }

        public IEnumerable<GPU> GetAll()
        {
            return _gpus;
        }

        public GPU GetById(int id)
        {
            return _gpus.FirstOrDefault(x => x.Id == id);
        }

        public GPU Update(GPU gpu)
        {
            var item = GetById(gpu.Id);
            if (item != null)
            {
                item.Name = gpu.Name;
                item.Quantity = gpu.Quantity;
                item.Price = gpu.Price;
                item.Vram = gpu.Vram;
                item.Cuda = gpu.Cuda;

                string updatedJSon = JsonConvert.SerializeObject(_gpus, Formatting.Indented);
                File.WriteAllText(filePath, updatedJSon);


                return item;

            }
            return null;
        }
    }
}
