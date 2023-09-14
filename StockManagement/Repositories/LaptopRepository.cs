namespace StockManagement
{
    public class LaptopRepository : IRepository<Laptop>
    {
        
        private List<Laptop> laptops;

        public LaptopRepository()
        {
            laptops = new List<Laptop>();
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
                item.Name = newStock.Name;
                item.Quantity = newStock.Quantity;
                item.Price = newStock.Price;
                item.ScreenSize = newStock.ScreenSize;
                item.Storage = newStock.Storage;
                item.Ram = newStock.Ram;


                return item;

            }
            return null;
        }
    }
}