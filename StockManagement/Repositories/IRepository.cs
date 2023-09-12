using StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockManagement
{
    internal interface IRepository<T> where T : Stock
    {
        T? GetById( int? id);
        List<T> GetAll();
        T Add( T item);
        T Update( int? id, T stock);
        void Delete( int? id);


    }


}
