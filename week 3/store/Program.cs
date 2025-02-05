using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
    internal class Program
    {
        static List<product> products = new List<product>();

        static void Main(string[] args)
        {
            int option = mainmenu();
            while (true)
            {
                switch (option)
                {
                    case 1:
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
                        products.Add(new product(name, category, price, quantity,remainingquantity));
                        Console.WriteLine("product Added succesfully");
                        break;
                        case 2:
                        showproducts();
                        break;
                        case 3:
                       Console.WriteLine($"price:{highestprice()}");
                        break;
                    case 4:
                        showtax();
                        break;
                        case 5:
                        reorderproduct();
                        break;
                       
                }
                option = mainmenu();

            }

        }
        static int mainmenu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Highest Price Product");
            Console.WriteLine("4. View Tax");
            Console.WriteLine("5. Reorder Product");
            Console.WriteLine("6. Exit");
            Console.Write("Enter option: ");

            int choice=int.Parse(Console.ReadLine());
            return choice;
        }
        static void showproducts()
        {
            Console.WriteLine("Products");
            foreach(var product in products )
            {
                Console.WriteLine($"Name:{product.name},category:{product.category},price:{product.price},Quantity:{product.quantity},Remaining Stock:{product.remainingquantity}");

            }
            Console.WriteLine();
            
          
        }
        static float highestprice()
        {
            float max = float.MinValue;
            for (int i = 0; i < products.Count; i++)

            {
if (products[i].price > max)
                {
                    max = products[i].price;
                }

            }
            return max;

        }
        static void showtax()
        {
            float tax = 0;
        foreach(var product in products)
            {
                if (product.category == "groceries")
                {
                    tax = product.price * 0.10f;
                }
                else if (product.category == "fruits")
                {
                    tax = product.price * 0.05f;
                }
                else {
                    tax = product.price * 0.15f;
                
                }
                Console.WriteLine($"Name:{product.name} ,TAX:{tax}");

            }

        }
        static void reorderproduct()
        {
            bool found = true;
            foreach (var product in products)
            {
                if (product.quantity < product.remainingquantity)
                {
                    Console.WriteLine($"product name:{product.name},product stock:{product.quantity},remaining stock:{product.remainingquantity}");
                }

            }
            if (!found)
            {
                Console.WriteLine("no products needs to be reordered");

            }
        }
    }
}
