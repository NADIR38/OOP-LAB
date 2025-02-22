using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale.Bl
{
   public  class productbl
    {
      
        public static void addProduct(models.Product product)
        {
            dal.productdl.products.Add(product);
            Console.WriteLine("Product added successfully");
        }
        public static void showProduct()
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
        public static string gethighestprice()
        {
            float max = 0;
            foreach (var item in dal.productdl.products)
            {
                if (item.price > max)
                {
                    max = item.price;
                    return $"the highest product name is {item.name} at {max}";

                }
            }
            return "";
        }
        public static void productreorder()
        {
            foreach (var item in dal.productdl.products)
            {
                if (item.minquan()==true)
                {
                    Console.WriteLine("Product needs to be reordered");
                    item.stock = item.stock + 50;
                }
            }
            Console.WriteLine("Product has been reordered");
        }
        public static void gettax()
        {
            foreach(var item in dal.productdl.products)
            {
                item.tax=item.GetSalesTax();
                Console.WriteLine($"{item.name} tax is {item.tax}");

            }
        }
       

        


    }
}
