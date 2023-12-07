using StockManagementLibraries.Models;

namespace StockManagementMVC.ViewModels
{
    public class ItemViewModel<T> where T : Stock
    {
        public T Item { get; set; }

        public ItemViewModel(T item)
        {
            Item = item;
        }

    }
}
