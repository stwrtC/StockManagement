
namespace StockManagement
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            List<GPU> gpus = CRUD_Stock.gpuRepository.getGPUs();
            List<Laptop> laptops = CRUD_Stock.laptopRepository.getLaptops();
            gpus.Add(new GPU("Nvidia GTX 950", 5, 209.99m, 2, 768));
            gpus.Add(new GPU("Nvidia RTX 4090 Ti", 1, 1699.99m, 24, 16384));
            laptops.Add(new Laptop("Chromebook", 5, 199, 17, 32, 512));

            bool cont = true;
            Console.WriteLine("Welcome to the Stock Management Console App");

            while (cont)
            {

                Console.WriteLine("Input '1' to add Laptop");
                Console.WriteLine("Input '2' to add GPU");
                Console.WriteLine("Input '3' to all stock");
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
                        CRUD_Stock.AddLaptop();
                        break;
                    case 2:
                        CRUD_Stock.AddGPU();
                        break;
                    case 3:
                        CRUD_Stock.ViewStock();
                        break;
                    case 4:
                        CRUD_Stock.GetLaptop();
                        break;
                    case 5:
                        CRUD_Stock.GetGPU();
                        break;
                    case 6:
                        var calc = new CalculateStock();
                        Console.Write("Laptops have ");
                        CalculateStock.StockLevel(calc.CalcLaptop(laptops));
                        Console.Write("GPUs have ");
                        CalculateStock.StockLevel(calc.CalcGPU(gpus));
                        Console.WriteLine($"The total stock of laptops is {calc.CalcLaptop(laptops)} and the total stock of GPUs is {calc.CalcGPU(gpus)}.");
                        break;
                    case 7:
                        calc = new CalculateStock();
                        Console.WriteLine($"The total value of all laptops is £{calc.LaptopValue(laptops)} and the total value of all GPUs is £{calc.GPUValue(gpus)}.");
                        break;

                    case 8:
                        CRUD_Stock.UpdateLaptop();
                        break;
                    case 9:
                        CRUD_Stock.UpdateGPU();
                        break;
                    case 10:
                        CRUD_Stock.DeleteLaptop();
                        break;
                    case 11:
                        CRUD_Stock.DeleteGPU();
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


