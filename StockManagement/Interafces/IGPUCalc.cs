using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    public interface IGPUCalc
    {
        int TotalStock(IStockRepository<GPU> gpuRepo);
        decimal? TotalValue(IStockRepository<GPU> gpuRepo);

    }
}
