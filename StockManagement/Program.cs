using StockManagement;
using StockManagement.Services;

namespace StockManagement
{
    internal class Program
    {

        private static IStockRepository<Laptop> _laptopRepo = new LaptopRepository();
        private static IStockRepository<GPU> _gpuRepo = new GPURepository();
        private static ILaptopCalc _laptopCalc = new LaptopCalc();
        private static IGPUCalc _gpuCalc = new GPUCalc();
        private static ISearchLaptop _searchLaptop = new SearchLaptop();
        private static ISearchGPU _searchGPU = new SearchGPU();
        public static void Main(string[] args)
        {
            CRUD_Stock crud = new CRUD_Stock(_laptopRepo, _gpuRepo, _searchLaptop, _searchGPU);
            bool cont = true;
            Console.WriteLine("Welcome to the Stock Management Console App");

            while (cont)
            {

                Console.WriteLine("Input '1' to add Laptop");
                Console.WriteLine("Input '2' to add GPU");
                Console.WriteLine("Input '3' to view all stock");
                Console.WriteLine("Input '4' to view Laptop by ID");
                Console.WriteLine("Input '5' to view GPU by ID");
                Console.WriteLine("Input '6' to view stock level");
                Console.WriteLine("Input '7' to view total value of stock");
                Console.WriteLine("Input '8' to update Laptops");
                Console.WriteLine("Input '9' to update GPUs");
                Console.WriteLine("Input '10' to delete Laptops");
                Console.WriteLine("Input '11' to delete GPUs");
                Console.WriteLine("Input '12' to exit program");
                int? input = int.Parse(Console.ReadLine());
                if (String.IsNullOrEmpty(input.ToString()))
                {
                    cont = false;
                    break;
                }
                switch (input)
                {
                    case 1:
                        crud.AddLaptop();
                        break;
                    case 2:
                        crud.AddGPU();
                        break;
                    case 3:
                        crud.ViewStock();
                        break;
                    case 4:
                        crud.GetLaptop();
                        break;
                    case 5:
                        crud.GetGPU();
                        break;
                    case 6:
                        Console.WriteLine($"The total stock of laptops is {_laptopCalc.TotalStock(_laptopRepo)} and the total stock of GPUs is {_gpuCalc.TotalStock(_gpuRepo)}.");
                        break;
                    case 7:
                        Console.WriteLine($"The total value of all laptops is £{_laptopCalc.TotalValue(_laptopRepo)} and the total value of all GPUs is £{_gpuCalc.TotalValue(_gpuRepo)}.");
                        break;

                    case 8:
                        crud.UpdateLaptop();
                        break;
                    case 9:
                        crud.UpdateGPU();
                        break;
                    case 10:
                        crud.DeleteLaptop();
                        break;
                    case 11:
                        crud.DeleteGPU();
                        break;
                    case 12:
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


