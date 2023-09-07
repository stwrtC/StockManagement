using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class Search
    {
        List<GPU> gpus = CRUD_Stock.gpuRepository.getGPUs();
        List<Laptop> laptops = CRUD_Stock.laptopRepository.getLaptops();

        public List<int?> GetGPUIdsByName(string? name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                List<int?> items = gpus.Where(x => x.Name == name).Select(x => x.Id).ToList();
                return items;
            }
            return null;
        }
        public List<int?> GetLaptopIdsByName(string? name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                List<int?> items = laptops.Where(x => x.Name == name).Select(x => x.Id).ToList();
                return items;
            }
            return null;
        }
    }
}
