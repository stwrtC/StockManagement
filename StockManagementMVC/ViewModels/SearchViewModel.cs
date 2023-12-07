using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{

    public class SearchViewModel
    {

        public string searchBy { get; set; }
        public string searchString { get; set; }
        public IEnumerable<GPU> GPUs { get; set; }
        public IEnumerable<Laptop> Laptops { get; set; }


        public SearchViewModel(string searchBy, string searchString, IEnumerable<GPU> _gpus, IEnumerable<Laptop> _laptops)
        {
            this.searchBy = searchBy;
            this.searchString = searchString;
            GPUs = _gpus;
            Laptops = _laptops;
        }
    }
}
