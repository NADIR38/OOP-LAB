using point_of_sale.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale.Bl
{
    public class customerbl
    {
        public static List<Product> cart = new List<Product>();
        public void addcustomer(customer customer)
        {
            dal.customerdl.customers.Add(customer);
        }
        public static  bool validatecus(string name, string pass)
        {
            foreach (var customer in dal.customerdl.customers)
            {
                if (customer.cus_name == name && customer.cus_pass == pass)
                {
                    return true;
                }

            }
            return false;
        }
        public static void showproducts()
        {
            foreach (var item in dal.productdl.products)
            {
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("Category: " + item.category);
                Console.WriteLine("Price: " + item.price);
                Console.WriteLine("Stock: " + item.stock);
                Console.WriteLine("MinStock: " + item.minstock);
                Console.WriteLine("Tax: " + item.tax);
            }
        }
        public static  void viewprofile(customer cus)
        {
            Console.WriteLine("Name: " + cus.cus_name);
            Console.WriteLine("Email: " + cus.cus_email);
            Console.WriteLine("Phone: " + cus.cus_phone);
            Console.WriteLine("Address: " + cus.cus_address);
        }
        public static  float buyproducts(string name, int quantity)
        {
            foreach (var item in dal.productdl.products)
            {
                if (item.name == name && item.stock > quantity)
                {
                    float total = (item.price * quantity) + (item.price * item.tax * quantity);
                    item.stock = item.stock - quantity;
                    cart.Add(new Product(item.name, item.category, item.price, quantity, item.minstock,item.tax)); 
                    return total;
                }
            }
            return 0;
        }
        public static void generatetotalbill()
        {
            float totalBill = 0;

            Console.WriteLine("\n--- Invoice ---");
            foreach (var item in cart)
            {
                float total = (item.price * item.stock) + (item.price * item.tax * item.stock);  
                Console.WriteLine($"{item.name} x {item.stock} = {total:C} (Includes Tax)");
                totalBill += total;
            }
            Console.WriteLine($"Total Bill: {totalBill:C}\n");
            cart.Clear();

        }


    }
}



    

