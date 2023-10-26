using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementLibraries.Models
{
    public class Laptop : Stock
    {
        [Required]
        public decimal ScreenSize { get; set; }
        [Required]
        public int Ram { get; set; }
        [Required]
        public int Storage { get; set; }
        
    }
}
