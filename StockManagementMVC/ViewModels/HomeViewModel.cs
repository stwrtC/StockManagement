using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{

    public class HomeViewModel
    {

        public string searchBy { get; set; }
        public string searchString { get; set; }

        public HomeViewModel(string searchBy, string searchString)
        {
            this.searchBy = searchBy;
            this.searchString = searchString;
        }
    }
}
