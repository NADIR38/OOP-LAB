using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static List<product> products = new List<product> (); 
        static void Main(string[] args)
        {
            int choice = mainmenu();
             int id;
         string name;
         string brand;
         string category;
         string country;
         float price;
            while (true) 
            {
                switch (choice) 
                {
                    case 1:

                        Console.WriteLine("enter product id");
                        id=int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter brand name");
                        brand = Console.ReadLine();
                        Console.WriteLine("Enter category");
                        category = Console.ReadLine();
                        Console.WriteLine("Enter country");
                        country = Console.ReadLine();
                        Console.WriteLine("Enter price");
                        price = int.Parse(Console.ReadLine());
                        products.Add(new product(id,name,brand,category,country,price));
                        Console.WriteLine("product added succesfully");
                        break;
                        case 2:
                        showproducts();
                        break;
                        case 3: storeworth(); break;
                }
                choice = mainmenu();

            }


        }
        static int mainmenu()
        {
            Console.WriteLine("1.Add Product");
            Console.WriteLine("2.Show products");
            Console.WriteLine("3:Store Worth");
            int option=int.Parse(Console.ReadLine());
            return option;
        }
        static void showproducts()
        {
            Console.WriteLine("Products");
            foreach (var product in products)
            {
                Console.WriteLine($"ID:{product.id}, Name:{product.name},brand name:{product.brand}, category:{product.category} , country{product.category},price:{product.price}");
            }

        }
        static void storeworth()
        {
            float result = 0;
            foreach(var product in products)
            {
                result += product.price;
                product.price = result;
            }
            Console.WriteLine($"Store worth:{result}");
        }
    }
}
