using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Laptop> Laptops { get; set; }
        public IEnumerable<GPU> GPUs { get; set; }
        public int StockTotal { get; set; }
        public decimal PriceTotal { get; set; }

        public HomeViewModel(IEnumerable<Laptop> laptops, IEnumerable<GPU> gPUs, int stockTotal, decimal priceTotal)
        {
            Laptops = laptops;
            GPUs = gPUs;
            StockTotal = stockTotal;
            PriceTotal = priceTotal;
        }
    }
}
