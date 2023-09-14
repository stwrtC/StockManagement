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
                var item = gpuRepo.GetById(id);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");
                GPU newGPU = new GPU(item.Name, item.Quantity, item.Price, item.Vram, item.Cuda);
                bool cont = true;
                while (cont)
                {
                    Console.WriteLine("Input '1' to update name");
                    Console.WriteLine("Input '2' to update VRam");
                    Console.WriteLine("Input '3' to to update cuda cores");
                    Console.WriteLine("Input '4' to update price");
                    Console.WriteLine("Input '5' to update quantity");
                    Console.WriteLine("Input '6' to view changes");
                    Console.WriteLine("Input '7' to submit changes");

                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Input Name");
                            string name = Console.ReadLine();
                            newGPU.Name = name;
                            break;
                        case 2:
                            Console.WriteLine("Input VRAM in GB");
                            int vram = int.Parse(Console.ReadLine());
                            newGPU.Vram = vram;
                            break;
                        case 3:
                            Console.WriteLine("Input cuda cores");
                            int cuda = int.Parse(Console.ReadLine());
                            newGPU.Cuda = cuda;
                            break;
                        case 4:
                            Console.WriteLine("Input Price");
                            decimal price = decimal.Parse(Console.ReadLine());
                            newGPU.Price = price;
                            break;
                        case 5:
                            Console.WriteLine("Input Stock Quantity");
                            int quantity = int.Parse(Console.ReadLine());
                            newGPU.Quantity = quantity;
                            break;
                        case 6:
                            Console.WriteLine($"Name: {newGPU.Name}, VRam: {newGPU.Vram}GB, Cuda: {newGPU.Cuda}, Price: {newGPU.Price}, Quantity: {newGPU.Quantity}");
                            break;
                        case 7:
                            var newItem = gpuRepo.Update(id, newGPU);
                            Console.WriteLine($"Name: {newItem.Name}, VRam: {newItem.Vram}GB, Cuda: {newItem.Cuda}, Price: {newItem.Price} , Quantity:  {newItem.Quantity}");
                            cont = false;
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
            }
        }
        public static void UpdateLaptop(IRepository<Laptop> laptopRepo)
        {
            Console.WriteLine("Please input the ID of the stock you would like to update");

            int id = int.Parse(Console.ReadLine());
            if (search.IDExists(laptopRepo.GetAll(), id))
            {
                var item = laptopRepo.GetById(id);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");
                Laptop newLaptop = new Laptop(item.Name, item.Quantity, item.Price, item.ScreenSize, item.Ram, item.Storage);
                bool cont = true;
                while (cont)
                {
                    Console.WriteLine("Input '1' to update name");
                    Console.WriteLine("Input '2' to update Ram");
                    Console.WriteLine("Input '3' to update storage");
                    Console.WriteLine("Input '4' to update screen size");
                    Console.WriteLine("Input '5' to update price");
                    Console.WriteLine("Input '6' to update quantity");
                    Console.WriteLine("Input '7' to view changes");
                    Console.WriteLine("Input '8' to submit changes");

                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Input Name");
                            string name = Console.ReadLine();
                            newLaptop.Name = name;
                            break;
                        case 2:
                            Console.WriteLine("Input RAM in GB");
                            int ram = int.Parse(Console.ReadLine());
                            newLaptop.Ram = ram;
                            break;
                        case 3:
                            Console.WriteLine("Input storage in GB");
                            int storage = int.Parse(Console.ReadLine());
                            newLaptop.Storage = storage;
                            break;
                        case 4:
                            Console.WriteLine("Screen size in inches");
                            int screen = int.Parse(Console.ReadLine());
                            newLaptop.ScreenSize = screen;
                            break;
                        case 5:
                            Console.WriteLine("Input Price");
                            decimal price = decimal.Parse(Console.ReadLine());
                            newLaptop.Price = price;
                            break;
                        case 6:
                            Console.WriteLine("Input Stock Quantity");
                            int quantity = int.Parse(Console.ReadLine());
                            newLaptop.Quantity = quantity;
                            break;
                        case 7:
                            Console.WriteLine($"Name: {newLaptop.Name}, Ram: {newLaptop.Ram}GB, Storage: {newLaptop.Storage}GB, Screen Size: {newLaptop.ScreenSize}, Price: {newLaptop.Price}, Quantity: {newLaptop.Quantity}");
                            break;
                        case 8:
                            var newItem = laptopRepo.Update(id, newLaptop);
                            Console.WriteLine($"ID: {newItem.Id}, Type: {nameof(Laptop)}, Name: {newItem.Name}, Ram: {newItem.Ram}GB, Storage: {newItem.Storage}GB, Screen Size: {newItem.ScreenSize}, Price: {newItem.Price}, Quantity: {newItem.Quantity}");
                            cont = false;
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
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
