using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class store
    {

        List<product>products = new  List<product>();

        public void AddProduct(product Product)
        {
            products.Add(Product);
            Console.WriteLine("product added succesfully");

        }
        public void viewProduct()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Name:{product.name},category:{product.category},price:{product.price},Quantity:{product.quantity},Remaining Stock:{product.remainingquantity}");
            }
            Console.WriteLine();
        }
        public float highestprice()
        {
            float maxprice = 0;
            for (int i = 1; i < products.Count; i++)
            {
                if (products[i].price > maxprice)
                {
                    maxprice = products[i].price;
                }
            }
            return maxprice;

        }
        public void viewtax()
        {
            float tax = 0;
            foreach (var product in products)
            {
                if (product.name == "groceries")
                {
                    tax = product.price * 0.10f;
                }
                if (product.name == "fruits")
                {
                    tax = product.price * 0.05f;
                }
                else
                {
                    tax = product.price * 0.15f;
                }
                Console.WriteLine($" product:{product.name},Salestax: {tax}");

            }
        }
        public void reorderproduct()
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
