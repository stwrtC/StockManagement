using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        private static int UUID = 0;
        public Stock(string name, string itemType, int stockAmount, decimal price) { 
            Name = name;
            ItemType = itemType;
            Quantity = stockAmount;
            Price = price;

            Id = UUID++;
        
        }





    }
}
