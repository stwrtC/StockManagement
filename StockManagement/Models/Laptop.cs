using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class Laptop : Stock
    {
        public decimal ScreenSize { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }



        //public Laptop(string name, int stockAmount, decimal? price, decimal screen, int ram, int storage)
        //    : base(name, stockAmount, price)
        //{
        //    ScreenSize = screen;
        //    Ram = ram;
        //    Storage = storage;
        //}
    }
}
