using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    public class GPUCalc : IGPUCalc
    {
        

        public int TotalStock(IStockRepository<GPU> gpuRepo)
        {
            int TotalStock = 0;

            foreach (GPU st in gpuRepo.GetAll())
            {
                TotalStock += st.Quantity;
            }
            return TotalStock;
        }

        public decimal? TotalValue(IStockRepository<GPU> gpuRepo)
        {
            decimal? totalValue = 0;
            foreach (GPU st in gpuRepo.GetAll())
            {
                totalValue += st.Price;
            }
            return totalValue;
        }
    }
}
