using StockManagement;
using StockManagement.Services;

namespace StockManagement
{
    internal class Program
    {

        private static IStockRepository<Laptop> _laptopRepo = new LaptopRepository();
        private static IStockRepository<GPU> _gpuRepo = new GPURepository();
        private static ILaptopCalc _laptopCalc = new LaptopCalc(_laptopRepo);
        private static IGPUCalc _gpuCalc = new GPUCalc(_gpuRepo);
        private static ISearchLaptop _searchLaptop = new SearchLaptop(_laptopRepo);
        private static ISearchGPU _searchGPU = new SearchGPU(_gpuRepo);
        private static Search _search = new Search(_gpuRepo, _laptopRepo);
        public static void Main(string[] args)
        {
            CRUD_Stock crud = new CRUD_Stock(_laptopRepo, _gpuRepo, _searchLaptop, _searchGPU);
            bool cont = true;
            Console.WriteLine("Welcome to the Stock Management Console App");

            while (cont)
            {
                int select;
                Console.WriteLine("Input '1' to add stock");
                Console.WriteLine("Input '2' to view all stock");
                Console.WriteLine("Input '3' to get stock by ID");
                Console.WriteLine("Input '4' to view stock statistics");
                Console.WriteLine("Input '5' to exit program");
                int? input = int.Parse(Console.ReadLine());
                if (String.IsNullOrEmpty(input.ToString()))
                {
                    cont = false;
                    break;
                }
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Input '1' to add Laptop");
                        Console.WriteLine("Input '2' to add GPU");
                        Console.WriteLine("Input '3' to exit program");
                        select = int.Parse(Console.ReadLine());
                        switch (select)
                        {
                            case 1:
                                Console.Clear();
                                crud.AddLaptop();
                                break;
                            case 2:
                                Console.Clear();
                                crud.AddGPU();
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        crud.ViewStock();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please input stock ID");
                        int id = int.Parse(Console.ReadLine());
                        switch (_search.GetType(id))
                        {
                            case "GPU":
                                crud.GetGPU(id);
                                Console.WriteLine("Input '1' to update GPUs");
                                Console.WriteLine("Input '2' to delete Laptops");
                                select = int.Parse(Console.ReadLine());
                                switch (select)
                                {
                                    case 1:
                                        crud.UpdateGPU(id);
                                        break;
                                    case 2:
                                        crud.DeleteGPU(id);
                                        break;
                                }

                                break;
                            case "Laptop":
                                crud.GetLaptop(id);
                                Console.WriteLine("Input '1' to update GPUs");
                                Console.WriteLine("Input '2' to delete Laptops");
                                select = int.Parse(Console.ReadLine());
                                switch (select)
                                {
                                    case 1:
                                        crud.UpdateLaptop(id);
                                        break;
                                    case 2:
                                        crud.DeleteLaptop(id);
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("{id} is not a valid ID.");
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"The total stock of laptops is {_laptopCalc.TotalStock()} and the total stock of GPUs is {_gpuCalc.TotalStock()}.");
                        Console.WriteLine($"The total value of all laptops is £{_laptopCalc.TotalValue()} and the total value of all GPUs is £{_gpuCalc.TotalValue()}.");
                        break;
                    case 5:
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("That was not a valid option, please try again.");
                        break;

                }
            }
        }

    }
}


