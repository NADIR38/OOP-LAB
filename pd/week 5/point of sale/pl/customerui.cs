using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale.pl
{
    class customerui
    {
        public static int customermenu()
        {
            Console.WriteLine("1. Show Products");
            Console.WriteLine("2. Buy Products");
            Console.WriteLine("3. Invoice");
            Console.WriteLine("4:view profile");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        public void showproductui()
        {
            Bl.customerbl.showproducts();
        }
        public void buyproductui()
        {
            Console.WriteLine("Enter Product Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"titl price is :{Bl.customerbl.buyproducts(name,quantity)}");
        }
        public void invoiceui()
        {
            Console.WriteLine("Invoice");
            foreach (var item in Bl.customerbl.cart)
            {
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("Category: " + item.category);
                Console.WriteLine("Price: " + item.price);
                Console.WriteLine("Quantity: " + item.stock);
                Console.WriteLine("Tax: " + item.tax);
            }
        }
    }
}
