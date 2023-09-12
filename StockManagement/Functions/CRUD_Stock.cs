namespace StockManagement
{
    public class CRUD_Stock
    {
        
        public static GPURepository gpuRepository = new GPURepository();
        public static LaptopRepository laptopRepository = new LaptopRepository();
        
        

        // Create
        public static void AddLaptop()
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
            var x = laptopRepository.Add(newLaptop);
            Console.WriteLine($"Laptop {x.Name} has been added with an ID of {x.Id}.");

        }
        public static void AddGPU()
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
            var x = gpuRepository.Add(newGPU);
            Console.WriteLine($"GPU {x.Name} has been added with an ID of {x.Id}.");

        }

        // Read
        public static void ViewStock()
        {
            foreach (Laptop x in laptopRepository.GetAll())
            {
                Console.WriteLine($"ID: {x.Id}, Type: {nameof(Laptop)}, Name: {x.Name}, Ram: {x.Ram}GB, Storage: {x.Storage}GB, Screen Size: {x.ScreenSize}, Price: {x.Price}, Quantity: {x.Quantity}");
            }
            foreach (GPU y in gpuRepository.GetAll())
            {
                Console.WriteLine($"ID: {y.Id}, Type: {nameof(GPU)}, Name: {y.Name}, VRam: {y.Vram}GB, Cuda: {y.Cuda}, Price: {y.Price}, Quantity: {y.Quantity}");
            }


        }

        public static void GetGPU()
        {
            Console.WriteLine("Please input the ID of the stock you would like to view");
            int id = int.Parse(Console.ReadLine());
            var item = gpuRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
                GetLaptop();
            }

        }
        public static void GetLaptop()
        {
            Console.WriteLine("Please input the ID of the stock you would like to view");
            int id = int.Parse(Console.ReadLine());            
            var item = laptopRepository.GetById( id);
            if(item != null)
            {
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
                GetLaptop();
            }

        }

        //Update
        public static void UpdateGPU()
        {
            Console.WriteLine("Please input the ID of the stock you would like to update");
            int id = int.Parse(Console.ReadLine());
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
            var item = gpuRepository.Update( id, newGPU);
            Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");


        }
        public static void UpdateLaptop()
        {
            Console.WriteLine("Please input the ID of the stock you would like to update");
            int id = int.Parse(Console.ReadLine());
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
            var item = laptopRepository.Update( id, newLaptop);
            Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");

        }


        //Delete
        public static void DeleteLaptop()
        {
            Console.WriteLine("Please input the ID of the stock you would like to remove");
            int? id = int.Parse(Console.ReadLine());
            if(id == null)
            {
                DeleteLaptop();
            }

            laptopRepository.Delete(id);
        }
        public static void DeleteGPU()
        {
            Console.WriteLine("Please input the ID of the stock you would like to remove");
            int? id = int.Parse(Console.ReadLine());
            if (id == null)
            {
                DeleteGPU();
            }
            gpuRepository.Delete(id);
        }


    }
}
