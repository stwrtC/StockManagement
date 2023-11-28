using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class UpdateViewModel<T> where T : Stock
    {
        public T Item { get; set; }
        public UpdateViewModel(T item) 
        { 
            Item = item;
        }
    }
}
