using StockManagement.Interafces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;


namespace StockManagement.Services
{
    public class CrudLaptop : ICrud
    {
        private readonly IStockRepository<Laptop> _laptopRepo;
        private readonly ISearchLaptop _searchLaptop;
        public CrudLaptop(IStockRepository<Laptop> laptopRepo, ISearchLaptop searchLaptop) 
        {
            _laptopRepo = laptopRepo;
            _searchLaptop = searchLaptop;
        }
        public void Add()
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

            Laptop newLaptop = new Laptop { Name = name, Quantity = quantity, Price = price, ScreenSize = screen, Ram = ram, Storage = storage };
            var x = _laptopRepo.Add(newLaptop);
            Console.WriteLine($"Laptop {x.Name} has been added with an ID of {x.Id}.");
        }

        public void Delete(int id)
        {
            if (_searchLaptop.IDExists(id) == false)
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

        public void Get(int id)
        {
            if (_searchLaptop.IDExists(id) == false)
            {
                Console.WriteLine("Error: Please input a valid ID");

            }
            var item = _laptopRepo.GetById(id);
            Console.WriteLine($"ID: {item.Id}, Type: {nameof(Laptop)}, Name: {item.Name}, Ram: {item.Ram}GB, Storage: {item.Storage}GB, Screen Size: {item.ScreenSize}, Price: {item.Price}, Quantity: {item.Quantity}");
        }

        public void Update(int id)
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

        public void ViewAll()
        {
            foreach (Laptop x in _laptopRepo.GetAll())
            {
                Console.WriteLine($"ID: {x.Id}, Type: {nameof(Laptop)}, Name: {x.Name}, Ram: {x.Ram}GB, Storage: {x.Storage}GB, Screen Size: {x.ScreenSize}, Price: {x.Price}, Quantity: {x.Quantity}");
            }

        }
    }
}
