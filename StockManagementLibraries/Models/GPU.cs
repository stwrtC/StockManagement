
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementLibraries.Models
{
    public class GPU : Stock
    {
        [Required]
        public int Vram { get; set; }
        [Required]
        public int Cuda { get; set; }

    }
}
