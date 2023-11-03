using log4net;
using log4net.Config;
using StockManagement;
using StockManagement.Interafces;
using StockManagementLibraries.Repositories;

using StockManagementLibraries;
using StockManagement.Services;
using StockManagementLibraries.Logging;

namespace StockManagement
{
    internal class Program
    {
        private static ILog _log = LogManager.GetLogger(typeof(Program));
        private static IStockRepository<Laptop> _laptopRepo = new JsonLaptopRepository();
        private static IStockRepository<GPU> _gpuRepo = new JsonGPURepository();
        private static ILaptopCalc _laptopCalc = new LaptopCalc(_laptopRepo);
        private static IGPUCalc _gpuCalc = new GPUCalc(_gpuRepo);
        private static ISearchLaptop _searchLaptop = new SearchLaptop(_laptopRepo);
        private static ISearchGPU _searchGPU = new SearchGPU(_gpuRepo);
        private static Search _search = new Search(_gpuRepo, _laptopRepo);
        public static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo("../../../log4net.config"));
            CrudGPU _crudGPU = new CrudGPU(_gpuRepo, _searchGPU);
            CrudLaptop _crudLaptop = new CrudLaptop(_laptopRepo,  _searchLaptop);
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
                        Console.WriteLine("Input '3' to return to menu");
                        select = int.Parse(Console.ReadLine());
                        switch (select)
                        {
                            case 1:
                                Console.Clear();
                                _crudLaptop.Add();
                                _log.Info($"{LogStrings.DefaultMessage}");
                                break;
                            case 2:
                                Console.Clear();
                                _crudGPU.Add();
                                _log.Info($"{LogStrings.DefaultMessage}");
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        _crudLaptop.ViewAll();
                        _crudGPU.ViewAll();
                        _log.Info($"{LogStrings.DefaultMessage}");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please input stock ID");
                        int id = int.Parse(Console.ReadLine());
                        switch (_search.GetType(id))
                        {
                            case "GPU":
                                _crudGPU.Get(id);
                                Console.WriteLine("Input '1' to update GPU");
                                Console.WriteLine("Input '2' to delete GPU");
                                Console.WriteLine("Input '3' to return to menu");
                                select = int.Parse(Console.ReadLine());
                                switch (select)
                                {
                                    case 1:
                                        _crudGPU.Update(id);
                                        _log.Info($"{LogStrings.RequestSuccessful}");
                                        break;
                                    case 2:
                                        _crudGPU.Delete(id);
                                        _log.Info($"{LogStrings.DefaultMessage}");
                                        break;
                                    case 3:
                                        break;
                                }

                                break;
                            case "Laptop":
                                _crudLaptop.Get(id);
                                Console.WriteLine("Input '1' to update Laptop");
                                Console.WriteLine("Input '2' to delete Laptop");
                                Console.WriteLine("Input '3' to return to menu");
                                select = int.Parse(Console.ReadLine());
                                switch (select)
                                {
                                    case 1:
                                        _crudLaptop.Update(id);
                                        _log.Info($"{LogStrings.RequestSuccessful}");
                                        break;
                                    case 2:
                                        _crudLaptop.Delete(id);
                                        _log.Info($"{LogStrings.DefaultMessage}");
                                        break;
                                    case 3:
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine($"{id} is not a valid ID.");
                                _log.Info($"{LogStrings.RequestFailed}");
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Input '1' to view total stock");
                        Console.WriteLine("Input '2' to view total value");
                        Console.WriteLine("Input '3' to return to menu");
                        select = int.Parse(Console.ReadLine());
                        switch (select)
                        {
                            case 1:
                                Console.WriteLine($"The total stock of laptops is {_laptopCalc.TotalStock()} and the total stock of GPUs is {_gpuCalc.TotalStock()}.");
                                break;
                            case 2:
                                Console.WriteLine($"The total value of all laptops is £{_laptopCalc.TotalValue()} and the total value of all GPUs is £{_gpuCalc.TotalValue()}.");
                                break;
                            case 3:
                                break;
                        }

                        break;
                    case 5:
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("That was not a valid option, please try again.");
                        _log.Info($"{LogStrings.DefaultMessage}");
                        break;

                }
            }
        }

    }
}


