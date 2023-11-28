using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class UpdateViewModel<T> where T : Stock
    {
        public T Item { get; set; }
        public T UpdatedItem { get; set; }

        public UpdateViewModel()
        {

        }
        public UpdateViewModel(T item, T updatedItem) 
        { 
            Item = item;
            UpdatedItem = updatedItem;
        }
    }
}
