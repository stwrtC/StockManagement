namespace StockManagementLibraries.Repositories
{
    public class DbLaptopRepository : IStockRepository<Laptop>
    {
        private readonly StockContext context;

        public DbLaptopRepository(StockContext _context) 
        {
            context = _context;
        }

        public Laptop Add(Laptop item)
        {
            context.Laptops.Add(item);
            context.SaveChanges();
            return GetById(item.Id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.Laptops.Remove(item);
                context.SaveChanges();
            }
        }

        public IEnumerable<Laptop> GetAll()
        {
            return context.Laptops;
        }

        public Laptop? GetById(int id)
        {
            return context.Laptops.FirstOrDefault(x => x.Id == id);
        }


        public Laptop? Update(Laptop laptop)
        {
            var item = GetById(laptop.Id);
            if (item != null)
            {
                item.Name = laptop.Name;
                item.Brand = laptop.Brand;
                item.Description = laptop.Description;
                item.Quantity = laptop.Quantity;
                item.Price = laptop.Price;
                item.ScreenSize = laptop.ScreenSize;
                item.Storage = laptop.Storage;
                item.Ram = laptop.Ram;

                context.Laptops.Update(item);
                context.SaveChanges();
                return item;

            }
            return null;
        }
    }
}