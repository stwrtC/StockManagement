using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    internal interface ILaptopCalc
    {
        int TotalStock(IRepository<Laptop> LaptopRepo);
        decimal? TotalValue(IRepository<Laptop> LaptopRepo);

    }
}
