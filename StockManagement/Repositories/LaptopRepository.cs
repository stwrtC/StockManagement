namespace StockManagement
{
    public class LaptopRepository : IRepository<Laptop>
    {
        
        private List<Laptop> laptops;

        public LaptopRepository()
        {
            laptops = new List<Laptop>();
        }
        public List<Laptop> getLaptops()
        {
            return laptops;
        }
        public Laptop Add(Laptop? item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            laptops.Add(item);
            return GetById(item.Id);
        }

        public void Delete( int? id)
        {
            var item = GetById( id);
            if (item != null)
            {
                laptops.Remove(item);
            }
        }

        public List<Laptop> GetAll()
        {
            return laptops;
        }

        public Laptop GetById( int? id)
        {
            return laptops.FirstOrDefault(x => x.Id == id);
        }


        public Laptop Update( int? id, Laptop newStock)
        {
            var item = GetById( id);
            if (item != null)
            {
                if (newStock.Name != null) { item.Name = newStock.Name; }
                if (newStock.Quantity.ToString() != null) { item.Quantity = newStock.Quantity; }
                if (newStock.Price.ToString() != null) { item.Price = newStock.Price; }
                if (newStock.ScreenSize.ToString() != null) { item.ScreenSize = newStock.ScreenSize; }
                if (newStock.Ram.ToString() != null) { item.Ram = newStock.Ram; }
                if (newStock.Storage.ToString() != null) { item.Storage = newStock.Storage; }

                return item;

            }
            return null;
        }
    }
}