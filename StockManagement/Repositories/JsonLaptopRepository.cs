using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Repositories
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

            List<Laptop> temp = JsonConvert.DeserializeObject<List<Laptop>>(fileContent);
            if (temp != null )
            {
                foreach (Laptop x in temp)
                {
                    _laptops.Add(x);
                }

            }
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
                Laptop itemToRemove = _laptops.Find(x => x.Id == id);
                string updatedJSon = JsonConvert.SerializeObject(_laptops, Formatting.Indented);
                File.WriteAllText(filePath, updatedJSon);
                _laptops.Remove(item);
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
