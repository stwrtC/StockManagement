using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    public class SearchLaptop : ISearchLaptop
    {
        public List<int?> GetIdsByName(IStockRepository<Laptop> laptopRepo, string? name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                List<int?> items = laptopRepo.GetAll().Where(x => x.Name == name).Select(x => x.Id).ToList();
                return items;
            }
            return null;
        }

        public bool IDExists(IStockRepository<Laptop> laptopRepo, int id)
        {
            return laptopRepo.GetAll().Where(x => x.Id == id).Any();
        }
    }
}
