using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{

    public class HomeViewModel
    {

        public string searchType { get; set; }
        public string searchString { get; set; }

        public HomeViewModel(string searchType, string searchString)
        {
            this.searchType = searchType;
            this.searchString = searchString;
        }
    }
}
