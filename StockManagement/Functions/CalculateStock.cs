using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class CalculateStock
    {
        public int CalcLaptop(List<Laptop> laptops)
        {
            int TotalStock = 0;

            foreach (Stock st in laptops)
            {
                if (st is Laptop)
                {
                    TotalStock += st.Quantity;

                }
            }
            return TotalStock;
        }

        public int CalcGPU(List<GPU> gpus)
        {
            int TotalStock = 0;
            foreach (Stock st in gpus)
            {
                if (st is GPU)
                {
                    TotalStock += st.Quantity;
                }
            }
            return TotalStock;
        }

        public decimal? LaptopValue(List<Laptop> laptops)
        {
            decimal? totalValue = 0;
            foreach (Stock st in laptops)
            {
                totalValue += st.Price;
            }
            return totalValue;
        }
        public decimal? GPUValue(List<GPU> gpus)
        {
            decimal? totalValue = 0;
            foreach (Stock st in gpus)
            {
                if (st is GPU)
                {
                    totalValue += st.Price;
                }
            }
            return totalValue;
        }


        public static void StockLevel(int TotalStock)
        {
            switch (TotalStock)
            {
                case int n when (n >= 1 && n < 6):
                    Console.WriteLine("Low Stock");
                    break;
                case int n when (n >= 6 && n < 12):
                    Console.WriteLine("Medium Stock");
                    break;
                case int n when (n >= 12):
                    Console.WriteLine("High Stock");
                    break;
            }
        }

    }
}
