using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Stock> stocks = new List<Stock>();
            stocks.Add(new Stock("Chromebook", "Laptop", 5, 199));
            stocks.Add(new Stock("Nvidia GTX 950", "GPU", 5, 209.99m));
            stocks.Add(new Stock("Nvidia RTX 4090 Ti", "GPU", 1, 1699.99m));

            bool cont = true;
            string yn = null;
            Console.WriteLine("Welcome to the Stock Management Console App");

            while (cont)
            {
                
                Console.WriteLine("Input '1' to add stock");
                Console.WriteLine("Input '2' to track stock level");
                Console.WriteLine("Input '3' to view total value");
                Console.WriteLine("Input '4' to remove stock");
                Console.WriteLine("Input '5' to update stock");
                Console.WriteLine("Input '6' to view all stock");
                Console.WriteLine("Input '7' to exit program");
                int input = int.Parse(Console.ReadLine());
                switch(input)
                {
                    case 1:
                        CRUD_Stock.AddStock(stocks);
                        break;

                    case 2:
                        var calc = new CalculateStock();
                        Console.Write("Laptops have ");
                        CalculateStock.StockLevel(calc.CalcLaptop(stocks));
                        Console.Write("GPUs have ");
                        CalculateStock.StockLevel(calc.CalcGPU(stocks));
                        Console.WriteLine($"The total stock of laptops is {calc.CalcLaptop(stocks)} and the total stock of GPUs is {calc.CalcGPU(stocks)}.");
                        break;
                    case 3:
                        calc = new CalculateStock();
                        Console.WriteLine($"The total value of all laptops is £{calc.LaptopValue(stocks)} and the total value of all GPUs is £{calc.GPUValue(stocks)}.");
                        break;
                    case 4:
                        CRUD_Stock.DeleteStock(stocks);                        
                        break;
                    case 5:
                        CRUD_Stock.UpdateStock(stocks);
                        break;
                    case 6:
                        CRUD_Stock.ViewStock(stocks);
                        break;
                    case 7:
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
