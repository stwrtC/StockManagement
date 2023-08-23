using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    internal class CRUD_Stock
    {
        public static void AddStock(List<Stock> stocks)
        {
            Console.WriteLine("Input Name");
            string name = Console.ReadLine();
            Console.WriteLine("Input Item Type");
            string type = Console.ReadLine();
            Console.WriteLine("Input Stock Quantity");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Price");
            decimal price = decimal.Parse(Console.ReadLine());

            Stock newStock = new Stock(name, type, quantity, price);
            stocks.Add(newStock);
            Console.WriteLine($"Stock {newStock.Name} has been added with an ID of {newStock.Id}.");
        }

        public static void ViewStock(List<Stock> stocks)
        {
            foreach (Stock stock in stocks)
            {
                Console.WriteLine($"ID: {stock.Id}, ProductName: {stock.Name}, ProductType: {stock.ItemType}," +
                    $" Quantity: {stock.Quantity}, Price: {stock.Price}");
            }
        }

        public static void DeleteStock(List<Stock> stocks)
        {
            ViewStock(stocks);
            Console.WriteLine("Please input the ID of the stock you would like to remove");
            int id = int.Parse(Console.ReadLine());
            foreach (Stock stock in stocks)
            {
                if (stock.Id.Equals(id))
                {
                    stocks.RemoveAt(stocks.IndexOf(stock));
                    Console.WriteLine("Successfully removed item");
                    ViewStock(stocks);
                    break;
                }
            }
        }

        public static void UpdateStock(List<Stock> stocks)
        {
            ViewStock(stocks);
            Console.WriteLine("Please input the ID of the stock you would like to update");
            int id = int.Parse(Console.ReadLine());
            foreach (Stock stock in stocks)
            {
                if (stock.Id.Equals(id))
                {
                    Console.WriteLine($"ID: {stock.Id}, ProductName: {stock.Name}, ProductType: {stock.ItemType}," +
                                        $" Quantity: {stock.Quantity}, Price: {stock.Price}");

                    Console.WriteLine("Input new value when prompted, leave input blank to keep original value.");
                    Console.WriteLine("Input Name");
                    string name = Console.ReadLine();
                    if(name != null) { stock.Name = name; }
                    Console.WriteLine("Input Item Type");
                    string type = Console.ReadLine();
                    if (type != null) { stock.ItemType = type; }
                    Console.WriteLine("Input Stock Quantity");
                    string quantity = Console.ReadLine();
                    if (quantity != null) { stock.Quantity = int.Parse(quantity); }
                    Console.WriteLine("Input Price");
                    string price = Console.ReadLine();
                    if (price != null) { stock.Price = int.Parse(price); }

                    Console.WriteLine($"ID: {stock.Id}, ProductName: {stock.Name}, ProductType: {stock.ItemType}," +
                    $" Quantity: {stock.Quantity}, Price: {stock.Price}");



                    break;
                }
            }


        }

    }
}
