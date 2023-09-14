using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    internal class LaptopCalc : ILaptopCalc
    {

        public int TotalStock(IRepository<Laptop> laptopRepo)
        {
            int TotalStock = 0;

            foreach (Laptop st in laptopRepo.GetAll())
            {
                TotalStock += st.Quantity;
            }
            return TotalStock;
        }

        public decimal? TotalValue(IRepository<Laptop> laptopRepo)
        {
            decimal? totalValue = 0;
            foreach (Laptop st in laptopRepo.GetAll())
            {
                totalValue += st.Price;
            }
            return totalValue;
        }
    }
}
