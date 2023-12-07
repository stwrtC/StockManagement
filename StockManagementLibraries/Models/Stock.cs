using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementLibraries.Models
{
    public abstract class Stock
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string Name { get; set; }
        [Required]
        [MaxLength(55)]
        public string Brand { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public string? ImageThumbnail {get; set; }
        public int Quantity { get; set; } = 0;
        [Required]
        public decimal Price { get; set; }

        private static int UUID = 1;
        
        public Stock()
        {
            Id = UUID++;
        }



    }
}
