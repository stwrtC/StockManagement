using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    public interface ISearchLaptop
    {
        List<int> GetIdsByName(string name);
        bool IDExists(int id);
    }
}
