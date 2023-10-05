using StockManagement.Interafces;
using StockManagement.Services;

namespace StockManagement
{
    public class CrudGPU : ICrud
    {
        private readonly IStockRepository<GPU> _gpuRepo;
        private readonly ISearchGPU _searchGPU;

        public CrudGPU(IStockRepository<GPU> gpuRepo, ISearchGPU searchGPU)
        {
            _gpuRepo = gpuRepo;
            _searchGPU = searchGPU;
        }


        // Create

        public void Add()
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
        public void ViewAll()
        {
            foreach (GPU y in _gpuRepo.GetAll())
            {
                Console.WriteLine($"ID: {y.Id}, Type: {nameof(GPU)}, Name: {y.Name}, VRam: {y.Vram}GB, Cuda: {y.Cuda}, Price: {y.Price}, Quantity: {y.Quantity}");
            }


        }

        public void Get(int id)
        {
            if (_searchGPU.IDExists(id) == false)
            {
                Console.WriteLine("Error: Please input a valid ID");

            }
            var item = _gpuRepo.GetById(id);
            Console.WriteLine($"ID: {item.Id}, Type: {nameof(GPU)}, Name: {item.Name}, VRam: {item.Vram}GB, Cuda: {item.Cuda}, Price: {item.Price}, Quantity: {item.Quantity}");

        }

        //Update
        public void Update(int id)
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


            //Delete
        public void Delete(int id)
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
