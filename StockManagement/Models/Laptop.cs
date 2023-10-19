using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class Laptop : Stock
    {
        [Required]
        public decimal ScreenSize { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }
        
    }
}
