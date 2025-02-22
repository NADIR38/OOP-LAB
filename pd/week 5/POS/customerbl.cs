using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
   public  class customerbl
    {
        public void addCustomer(customer customer)
        {
            customerdl.customers.Add(customer);
            Console.WriteLine("Customer Added Successfully");
        }
        public void showcustomer()
        {
            foreach (customer customer in customerdl.customers)
            {
                Console.WriteLine("Name: " + customer.cus_name);
                Console.WriteLine("Email: " + customer.cus_email);
                Console.WriteLine("Phone: " + customer.cus_phone);
                Console.WriteLine("Address: " + customer.cus_address);
            }
        }
        public void purchaseproduct(string name,int quantity)
        {
            foreach (Product product in productdl.products)
            {
                if (product.name == name)
                {
                    Console.WriteLine("Product Found");
                    if (product.stock >= quantity)
                    {
                        product.stock = product.stock - quantity;
                        float total = product.price * quantity+(product.price-(product.price*product.GetSalesTax()));
                        Console.WriteLine("Product Purchased Successfully ");
                        Console.WriteLine($"you purchased {quantity} {product.name} at {product.price} each and your tax is{product.price-(product.price*product.GetSalesTax())}");
                    }
                    else
                    {
                        Console.WriteLine("Product Out of Stock");
                    }
                }
            }
        }

       
    }
}
