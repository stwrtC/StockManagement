using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class Search
    {
        public List<int?> GetIdsByName<T>(List<T> stock, string? name) where T: Stock
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                List<int?> items = stock.Where(x => x.Name == name).Select(x => x.Id).ToList();
                return items;
            }
            return null;
        }

        public bool IDExists<T>(List<T> stock, int id) where T : Stock
        {
            return stock.Where(x => x.Id == id).Any();
        }
    }
}
