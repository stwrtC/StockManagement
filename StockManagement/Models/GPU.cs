
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class GPU : Stock
    {
        [Required]
        public int Vram { get; set; }
        public int Cuda { get; set; }

    }
}
