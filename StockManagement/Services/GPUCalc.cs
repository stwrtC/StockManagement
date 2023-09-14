using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    internal class GPUCalc : IGPUCalc
    {
        

        public int TotalStock(IRepository<GPU> gpuRepo)
        {
            int TotalStock = 0;

            foreach (GPU st in gpuRepo.GetAll())
            {
                TotalStock += st.Quantity;
            }
            return TotalStock;
        }

        public decimal? TotalValue(IRepository<GPU> gpuRepo)
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
