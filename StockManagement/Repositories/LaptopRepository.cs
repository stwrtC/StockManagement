namespace StockManagement
{
    public class LaptopRepository : IStockRepository<Laptop>
    {
        
        private List<Laptop> _laptops;

        public LaptopRepository()
        {
            _laptops = new List<Laptop>()
            {
                new Laptop()
                {Name= "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512}
            };
        }
        public Laptop Add(Laptop? item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _laptops.Add(item);
            return GetById(item.Id);
        }

        public void Delete( int? id)
        {
            var item = GetById( id);
            if (item != null)
            {
                _laptops.Remove(item);
            }
        }

        public IEnumerable<Laptop> GetAll()
        {
            return _laptops;
        }

        public Laptop GetById( int? id)
        {
            return _laptops.FirstOrDefault(x => x.Id == id);
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