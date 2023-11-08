using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class GPUListViewModel
    {
        public IEnumerable<GPU> GPUs { get; set; }
        public string? StockType { get; set; }
        public GPUListViewModel(IEnumerable<GPU> gpus) 
        { 
            GPUs = gpus;
            StockType = typeof(GPU).ToString();
        }
    }
}
