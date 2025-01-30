using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            store Store = new store();
           

            while (true)
            {
                int choice = MainMenu();
                switch (choice)
                {
                    case 1:
                        AddProduct(Store);
                        break;
                    case 2:
                        Store.viewProduct();
                        break;
                    case 3:
                        Console.WriteLine($"Highest price product: {Store.highestprice()}");
                        break;
                    case 4:
                        Store.viewtax();
                        break;
                    case 5:
                        Store.reorderproduct();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static int MainMenu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Highest Price Product");
            Console.WriteLine("4. View Tax");
            Console.WriteLine("5. Reorder Product");
            Console.WriteLine("6. Exit");
            Console.Write("Enter option: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6:");
            }
            return choice;
        }

        public static void AddProduct(store Store)
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter category: ");
            string category = Console.ReadLine();
            Console.Write("Enter price: ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter minimum stock for reorder: ");
            int remainingquantity = int.Parse(Console.ReadLine());
            product newProduct = new product(name, category, price, quantity, remainingquantity);
            Store.AddProduct(newProduct);

        }

    }

}

