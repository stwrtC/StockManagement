using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class ShipmentViewModel
    {
        public IEnumerable<GPU> GPUs { get; set; }
        public IEnumerable<Laptop> Laptops { get; set; }

        public ShipmentViewModel(IEnumerable<GPU> gpus, IEnumerable<Laptop> laptops)
        {
            GPUs = gpus;
            Laptops = laptops;
        }




    }
}
