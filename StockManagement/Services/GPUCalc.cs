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
        private readonly IStockRepository<GPU> _gpuRepo;
        public GPUCalc(IStockRepository<GPU> gpuRepo)
        {
            _gpuRepo = gpuRepo;
        }

        public int TotalStock()
        {
            int TotalStock = 0;

            foreach (GPU st in _gpuRepo.GetAll())
            {
                TotalStock += st.Quantity;
            }
            return TotalStock;
        }

        public decimal? TotalValue()
        {
            decimal? totalValue = 0;
            foreach (GPU st in _gpuRepo.GetAll())
            {
                totalValue += st.Price;
            }
            return totalValue;
        }
    }
}
