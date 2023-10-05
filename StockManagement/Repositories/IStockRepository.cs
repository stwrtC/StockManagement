using StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockManagement
{
    public interface IStockRepository<T> where T : Stock
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T item);
        T Update(T stock);
        void Delete(int id);


    }


}
