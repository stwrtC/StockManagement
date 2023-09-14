using System.ComponentModel.Design;
using StockManagement;
using StockManagement.Services;

namespace StockManagement
{
    internal class Program
    {

        private static IRepository<Laptop> _laptop = new LaptopRepository();
        private static IRepository<GPU> _gpu = new GPURepository();
        private static ILaptopCalc _laptopCalc = new LaptopCalc();
        private static IGPUCalc _gpuCalc = new GPUCalc();
        public static void Main(string[] args)
        {            

            List<GPU> gpus = _gpu.GetAll();
            List<Laptop> laptops = _laptop.GetAll();
            gpus.Add(new GPU("Nvidia GTX 950", 5, 209.99m, 2, 768));
            gpus.Add(new GPU("Nvidia RTX 4090 Ti", 1, 1699.99m, 24, 16384));
            laptops.Add(new Laptop("Chromebook", 5, 199, 17, 32, 512));

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
                        CRUD_Stock.AddLaptop(_laptop);
                        break;
                    case 2:
                        CRUD_Stock.AddGPU(_gpu);
                        break;
                    case 3:
                        CRUD_Stock.ViewStock(_laptop, _gpu);
                        break;
                    case 4:
                        CRUD_Stock.GetLaptop(_laptop);
                        break;
                    case 5:
                        CRUD_Stock.GetGPU(_gpu);
                        break;
                    case 6:
                        Console.WriteLine($"The total stock of laptops is {_laptopCalc.TotalStock(_laptop)} and the total stock of GPUs is {_gpuCalc.TotalStock(_gpu)}.");
                        break;
                    case 7:
                        Console.WriteLine($"The total value of all laptops is £{_laptopCalc.TotalValue(_laptop)} and the total value of all GPUs is £{_gpuCalc.TotalValue(_gpu)}.");
                        break;

                    case 8:
                        CRUD_Stock.UpdateLaptop(_laptop);
                        break;
                    case 9:
                        CRUD_Stock.UpdateGPU(_gpu);
                        break;
                    case 10:
                        CRUD_Stock.DeleteLaptop(_laptop);
                        break;
                    case 11:
                        CRUD_Stock.DeleteGPU(_gpu);
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


