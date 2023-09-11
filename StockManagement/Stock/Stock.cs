using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public abstract class Stock
    {
        public int? Id { get; }
        public string? Name { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal? Price { get; set; }

        private static int UUID = 1;
        public Stock(string name, int stockAmount, decimal price)
        {
            Name = name;
            Quantity = stockAmount;
            Price = price;
            Id = UUID++;
        }



    }
}
