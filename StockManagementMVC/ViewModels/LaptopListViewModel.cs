using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class LaptopListViewModel
    {
        public IEnumerable<Laptop> Laptops { get; set; }
        public string? StockType { get; set; }
        public LaptopListViewModel(IEnumerable<Laptop> laptops) 
        { 
            Laptops = laptops;
            StockType = nameof(Laptop);
        }
    }
}
