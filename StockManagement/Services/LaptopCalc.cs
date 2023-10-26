using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;


namespace StockManagement.Services
{
    public class LaptopCalc : ILaptopCalc
    {
        private readonly IStockRepository<Laptop> _laptopRepo;
        public LaptopCalc(IStockRepository<Laptop> laptopRepo)
        {
            _laptopRepo = laptopRepo;
        }

        public int TotalStock()
        {
            int TotalStock = 0;

            foreach (Laptop st in _laptopRepo.GetAll())
            {
                TotalStock += st.Quantity;
            }
            return TotalStock;
        }

        public decimal? TotalValue()
        {
            decimal? totalValue = 0;
            foreach (Laptop st in _laptopRepo.GetAll())
            {
                totalValue += st.Price;
            }
            return totalValue;
        }
    }
}
