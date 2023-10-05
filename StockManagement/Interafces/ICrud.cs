using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Interafces
{
    public interface ICrud
    {
        void Add();
        void Get(int id);
        void ViewAll();
        void Update(int id);
        void Delete(int id);
    }
}
