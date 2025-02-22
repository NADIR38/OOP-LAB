using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class productbl
    {
        public static void addProduct(Product product)
        {
            productdl.products.Add(product);
        }
        public void showproduct()
        {
            foreach (Product product in productdl.products)
            {
                Console.WriteLine("Name: " + product.name);
                Console.WriteLine("Category: " + product.category);
                Console.WriteLine("Price: " + product.price);
                Console.WriteLine("Stock: " + product.stock);
                Console.WriteLine("Minimum Stock: " + product.minstock);
            }
        }
        /* public void highestprice()
         {

             for (int i = 0; i < products.Count; i++)
             {
                 for (int j = i + 1; j < products.Count; j++)
                 {
                     if (products[j].price < products[j + 1].price)
                     {
                         Product temp = products[j];
                         products[j] = products[j + 1];
                         products[j + 1] = temp;
                     }
                 }
             }
         }*/
        public void HighPrice()
        {
            List<Product> sortedProducts = productdl.products.OrderByDescending(p => p.price).ToList();

            Product highestProduct = sortedProducts.FirstOrDefault();

            if (highestProduct != null)
            {
                Console.WriteLine("Highest Priced Product: " + highestProduct.price);
            }
        }
        public void showtax()
        {
            foreach (Product product in productdl.products)
            {
                Console.WriteLine("Name: " + product.name);
                Console.WriteLine("Category: " + product.category);
                Console.WriteLine("Price: " + product.price);
                Console.WriteLine("Tax: " + product.GetSalesTax());
            }
        }
        public void prductstobeordered(string productname,int quantity_reorder)
        {
            foreach (Product product in productdl.products)
            {
                if (product.name == productname)
                {
                    if(product.minquan()==true)
                    {
                        product.stock = product.stock + quantity_reorder;
                    }
                }
            }




        }
    }
}