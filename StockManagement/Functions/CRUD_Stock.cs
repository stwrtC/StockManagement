namespace StockManagement
{
    public class CRUD_Stock
    {
        public static Search search = new Search();


        // Create
        public static void AddLaptop(IRepository<Laptop> laptopRepo)
        {

            Console.WriteLine("Input Name");
            string? name = Console.ReadLine();
            Console.WriteLine("Input Stock Quantity");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Price");
            decimal price = decimal.Parse(Console.ReadLine()) + 'm';
            Console.WriteLine("Input screen size in inches");
            decimal screen = decimal.Parse(Console.ReadLine()) + 'm';
            Console.WriteLine("Input RAM in GB");
            int ram = int.Parse(Console.ReadLine());
            Console.WriteLine("Input storage size in GB");
            int storage = int.Parse(Console.ReadLine());

            Laptop newLaptop = new Laptop(name, quantity, price, screen, ram, storage);
            var x = laptopRepo.Add(newLaptop);
            Console.WriteLine($"Laptop {x.Name} has been added with an ID of {x.Id}.");

        }
        public static void AddGPU(IRepository<GPU> gpuRepo)
        {
            Console.WriteLine("Input Name");
            string? name = Console.ReadLine();
            Console.WriteLine("Input Stock Quantity");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Price");
            decimal price = decimal.Parse(Console.ReadLine()) + 'm';
            Console.WriteLine("Input VRAM in GB");
            int vram = int.Parse(Console.ReadLine());
            Console.WriteLine("Input cuda cores");
            int cuda = int.Parse(Console.ReadLine());

            GPU newGPU = new GPU(name, quantity, price, vram, cuda);
            var x = gpuRepo.Add(newGPU);
            Console.WriteLine($"GPU {x.Name} has been added with an ID of {x.Id}.");

        }

        // Read
        public static void ViewStock(IRepository<Laptop> laptopRepo, IRepository<GPU> gpuRepo)
        {
            foreach (Laptop x in laptopRepo.GetAll())
            {
                Console.WriteLine($"ID: {x.Id}, Type: {nameof(Laptop)}, Name: {x.Name}, Ram: {x.Ram}GB, Storage: {x.Storage}GB, Screen Size: {x.ScreenSize}, Price: {x.Price}, Quantity: {x.Quantity}");
            }
            foreach (GPU y in gpuRepo.GetAll())
            {
                Console.WriteLine($"ID: {y.Id}, Type: {nameof(GPU)}, Name: {y.Name}, VRam: {y.Vram}GB, Cuda: {y.Cuda}, Price: {y.Price}, Quantity: {y.Quantity}");
            }


        }

        public static void GetGPU(IRepository<GPU> gpuRepo)
        {
            Console.WriteLine("Please input the ID of the stock you would like to view");
            int id = int.Parse(Console.ReadLine());
            if (search.IDExists(gpuRepo.GetAll(), id))
            {
                var item = gpuRepo.GetById(id);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
                //GetGPU();
            }           
        }
        public static void GetLaptop(IRepository<Laptop> laptopRepo)
        {
            Console.WriteLine("Please input the ID of the stock you would like to view");
            int id = int.Parse(Console.ReadLine()); 
            if(search.IDExists(laptopRepo.GetAll(), id))
            {
                var item = laptopRepo.GetById(id);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");
            }            
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
                //GetLaptop();
            }
        }

        //Update
        public static void UpdateGPU(IRepository<GPU> gpuRepo)
        {
            Console.WriteLine("Please input the ID of the stock you would like to update");
            int id = int.Parse(Console.ReadLine());
            if (search.IDExists(gpuRepo.GetAll(), id))
            {
                Console.WriteLine("Input new value when prompted, leave input blank to keep original value.");
                Console.WriteLine("Input Name");
                string name = Console.ReadLine();
                Console.WriteLine("Input Stock Quantity");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Price");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Input VRAM in GB");
                int vram = int.Parse(Console.ReadLine());
                Console.WriteLine("Input cuda cores");
                int cuda = int.Parse(Console.ReadLine());

                GPU newGPU = new GPU(name, quantity, price, vram, cuda);
                var item = gpuRepo.Update(id, newGPU);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
            else 
            {
                Console.WriteLine("Error: Please input a valid ID");
                //UpdateGPU();
            }



        }
        public static void UpdateLaptop(IRepository<Laptop> laptopRepo)
        {
            Console.WriteLine("Please input the ID of the stock you would like to update");
            int id = int.Parse(Console.ReadLine());
            if (search.IDExists(laptopRepo.GetAll(), id))
            {
                Console.WriteLine("Input new value when prompted, leave input blank to keep original value.");
                Console.WriteLine("Input Name");
                string name = Console.ReadLine();
                Console.WriteLine("Input Stock Quantity");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Input Price");
                decimal price = decimal.Parse(Console.ReadLine()) + 'm';
                Console.WriteLine("Input screen size in inches");
                decimal screen = decimal.Parse(Console.ReadLine()) + 'm';
                Console.WriteLine("Input RAM in GB");
                int ram = int.Parse(Console.ReadLine());
                Console.WriteLine("Input storage size in GB");
                int storage = int.Parse(Console.ReadLine());

                Laptop newLaptop = new Laptop(name, quantity, price, screen, ram, storage);
                var item = laptopRepo.Update(id, newLaptop);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");

            }
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
                //UpdateLaptop();
            }

        }


        //Delete
        public static void DeleteLaptop(IRepository<Laptop> laptopRepo)
        {
            Console.WriteLine("Please input the ID of the stock you would like to remove");
            int id = int.Parse(Console.ReadLine());
            if(search.IDExists(laptopRepo.GetAll(), id) == false)
            {
                //DeleteLaptop();
            }

            laptopRepo.Delete(id);
        }
        public static void DeleteGPU(IRepository<GPU> gpuRepo)
        {
            Console.WriteLine("Please input the ID of the stock you would like to remove");
            int id = int.Parse(Console.ReadLine());
            if (search.IDExists(gpuRepo.GetAll(), id) == false)
            {
                //DeleteGPU();
            }
            gpuRepo.Delete(id);
        }


    }
}
