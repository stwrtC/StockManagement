
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class GPU : Stock
    {
        public int Vram { get; set; }
        public int Cuda { get; set; }



        public GPU(string name, int stockAmount, decimal? price, int vram, int cuda)
            : base(name, stockAmount, price)
        {
            Vram = vram;
            Cuda = cuda;

        }




    }
}
