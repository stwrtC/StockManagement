using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    internal interface IGPUCalc
    {
        int TotalStock(IRepository<GPU> gpuRepo);
        decimal? TotalValue(IRepository<GPU> gpuRepo);

    }
}
