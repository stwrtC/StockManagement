using StockManagement.Services;

namespace StockManagement
{
    public class CRUD_Stock
    {
        private readonly IStockRepository<Laptop> _laptopRepo;
        private readonly IStockRepository<GPU> _gpuRepo;
        private readonly ISearchLaptop _searchLaptop;
        private readonly ISearchGPU _searchGPU;

        public CRUD_Stock(IStockRepository<Laptop> laptopRepo, IStockRepository<GPU> gpuRepo, ISearchLaptop searchLaptop, ISearchGPU searchGPU)
        {
            _laptopRepo = laptopRepo;
            _gpuRepo = gpuRepo;
            _searchLaptop = searchLaptop;
            _searchGPU = searchGPU;
        }


        // Create

        public void AddLaptop()
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

            Laptop newLaptop = new Laptop { Name = name, Quantity = quantity , Price = price, ScreenSize = screen, Ram = ram, Storage = storage };
            var x = _laptopRepo.Add(newLaptop);
            Console.WriteLine($"Laptop {x.Name} has been added with an ID of {x.Id}.");

        }
        public void AddGPU()
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

            GPU newGPU = new GPU() {Name = name, Quantity = quantity, Price = price, Vram = vram, Cuda = cuda };
            var x = _gpuRepo.Add(newGPU);
            Console.WriteLine($"GPU {x.Name} has been added with an ID of {x.Id}.");

        }

        // Read
        public void ViewStock()
        {
            foreach (Laptop x in _laptopRepo.GetAll())
            {
                Console.WriteLine($"ID: {x.Id}, Type: {nameof(Laptop)}, Name: {x.Name}, Ram: {x.Ram}GB, Storage: {x.Storage}GB, Screen Size: {x.ScreenSize}, Price: {x.Price}, Quantity: {x.Quantity}");
            }
            foreach (GPU y in _gpuRepo.GetAll())
            {
                Console.WriteLine($"ID: {y.Id}, Type: {nameof(GPU)}, Name: {y.Name}, VRam: {y.Vram}GB, Cuda: {y.Cuda}, Price: {y.Price}, Quantity: {y.Quantity}");
            }


        }

        public void GetGPU(int id)
        {
            if (_searchGPU.IDExists(id) == false)
            {
                Console.WriteLine("Error: Please input a valid ID");

            }
            var item = _gpuRepo.GetById(id);
            Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");

        }
        public void GetLaptop(int id)
        {
            if(_searchLaptop.IDExists(id) == false)
            {
                Console.WriteLine("Error: Please input a valid ID");

            }
            var item = _laptopRepo.GetById(id);
            Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");

        }

        //Update
        public void UpdateGPU(int id)
        {

            if (_searchGPU.IDExists(id))
            {
                var item = _gpuRepo.GetById(id);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");
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
                    Console.WriteLine("Input '8' to exit without submitting");

                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Input Name");
                            string name = Console.ReadLine();
                            item.Name = name;
                            break;
                        case 2:
                            Console.WriteLine("Input VRAM in GB");
                            int vram = int.Parse(Console.ReadLine());
                            item.Vram = vram;
                            break;
                        case 3:
                            Console.WriteLine("Input cuda cores");
                            int cuda = int.Parse(Console.ReadLine());
                            item.Cuda = cuda;
                            break;
                        case 4:
                            Console.WriteLine("Input Price");
                            decimal price = decimal.Parse(Console.ReadLine());
                            item.Price = price;
                            break;
                        case 5:
                            Console.WriteLine("Input Stock Quantity");
                            int quantity = int.Parse(Console.ReadLine());
                            item.Quantity = quantity;
                            break;
                        case 6:
                            Console.WriteLine($"Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");
                            break;
                        case 7:
                            var newItem = _gpuRepo.Update(item);
                            Console.WriteLine($"ID: {newItem.Id} has been updated successfully");
                            Console.WriteLine($"Name: {newItem.Name}, VRam: {newItem.Vram}GB, Cuda: {newItem.Cuda}, Price: {newItem.Price} , Quantity:  {newItem.Quantity}");
                            cont = false;
                            break;
                        case 8:
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Error: Please input a valid ID");
            }
        }
        public void UpdateLaptop(int id)
        {
            if (_searchLaptop.IDExists(id))
            {
                var item = _laptopRepo.GetById(id);
                Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");
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
                    Console.WriteLine("Input '9' to exit without submitting");


                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Input Name");
                            string name = Console.ReadLine();
                            item.Name = name;
                            break;
                        case 2:
                            Console.WriteLine("Input RAM in GB");
                            int ram = int.Parse(Console.ReadLine());
                            item.Ram = ram;
                            break;
                        case 3:
                            Console.WriteLine("Input storage in GB");
                            int storage = int.Parse(Console.ReadLine());
                            item.Storage = storage;
                            break;
                        case 4:
                            Console.WriteLine("Screen size in inches");
                            int screen = int.Parse(Console.ReadLine());
                            item.ScreenSize = screen;
                            break;
                        case 5:
                            Console.WriteLine("Input Price");
                            decimal price = decimal.Parse(Console.ReadLine());
                            item.Price = price;
                            break;
                        case 6:
                            Console.WriteLine("Input Stock Quantity");
                            int quantity = int.Parse(Console.ReadLine());
                            item.Quantity = quantity;
                            break;
                        case 7:
                            Console.WriteLine($"Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");
                            break;
                        case 8:
                            var newItem = _laptopRepo.Update(item);
                            Console.WriteLine($"ID: {newItem.Id} has been updated successfully");
                            Console.WriteLine($"ID: {newItem.Id}, Type: {nameof(Laptop)}, Name: {newItem.Name}, Ram: {newItem.Ram}GB, Storage: {newItem.Storage}GB, Screen Size: {newItem.ScreenSize}, Price: {newItem.Price}, Quantity: {newItem.Quantity}");
                            cont = false;
                            break;
                        case 9:
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
        public void DeleteLaptop(int id)
        {
            if(_searchLaptop.IDExists(id) == false)
            {
                Console.WriteLine("Error: Please input a valid ID");
            }
            var item = _laptopRepo.GetById(id);
            Console.Clear();
            Console.WriteLine($"Are you sure you want to delete ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name} from the system?");
            Console.WriteLine("Type 1 for YES and 2 for NO");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    _laptopRepo.Delete(id);
                    Console.WriteLine("Entry has been deleted successfully");
                    break;
                case 2:
                    break;
            }
        }
        public void DeleteGPU(int id)
        {
            if (_searchGPU.IDExists(id) == false)
            {
                Console.WriteLine("Error: Please input a valid ID");
            }
            var item = _gpuRepo.GetById(id);
            Console.Clear();
            Console.WriteLine($"Are you sure you want to delete ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name} from the system?");
            Console.WriteLine("Type 1 for YES and 2 for NO");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    _gpuRepo.Delete(id);
                    Console.WriteLine("Entry has been deleted successfully");
                    break;
                case 2:
                    break;
            }

        }


    }
}
