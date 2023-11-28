using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class ListViewModel<T> where T : Stock
    {
        public IEnumerable<T> StockList { get; set; }
        public string? StockType { get; set; }
        public ListViewModel(IEnumerable<T> stockList) 
        { 
            StockList = stockList;
            StockType = typeof(T).ToString();
        }
    }
}
