using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockManagementLibraries.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementLibraries.Repositories
{
    public class JsonLaptopRepository : IStockRepository<Laptop>
    {
        private readonly string filePath = @"C:\Users\stewartc\Documents\Laptops.json";        
        private List<Laptop> _laptops;


        public JsonLaptopRepository() 
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            string fileContent = File.ReadAllText(filePath);
            _laptops = new List<Laptop>();

            _laptops = JsonConvert.DeserializeObject<List<Laptop>>(fileContent);
            
        }
        public Laptop Add(Laptop item)
        {
            _laptops.Add(item);
            string updatedJSon = JsonConvert.SerializeObject(_laptops, Formatting.Indented);
            File.WriteAllText(filePath, updatedJSon);

            return GetById(item.Id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _laptops.Remove(item);
                Laptop itemToRemove = _laptops.Find(x => x.Id == id);
                string updatedJSon = JsonConvert.SerializeObject(_laptops, Formatting.Indented);
                File.WriteAllText(filePath, updatedJSon);
            }
        }

        public IEnumerable<Laptop> GetAll()
        {
            return _laptops;
        }

        public Laptop GetById(int id)
        {
            return _laptops.FirstOrDefault(x => x.Id == id);
        }

        public Laptop Update(Laptop laptop)
        {
            var item = GetById(laptop.Id);
            if (item != null)
            {
                item.Name = laptop.Name;
                item.Brand = laptop.Brand;
                item.Description = laptop.Description;
                item.ImageThumbnail = laptop.ImageThumbnail;
                item.Quantity = laptop.Quantity;
                item.Price = laptop.Price;
                item.ScreenSize = laptop.ScreenSize;
                item.Storage = laptop.Storage;
                item.Ram = laptop.Ram;

                string updatedJSon = JsonConvert.SerializeObject(_laptops, Formatting.Indented);
                File.WriteAllText(filePath, updatedJSon);


                return item;

            }
            return null;
        }
    }
}
