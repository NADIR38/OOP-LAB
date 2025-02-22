using point_of_sale.Bl;
using point_of_sale.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale.pl
{
    public class adminui
    {
        public static int adminmenu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2: Show Product");
            Console.WriteLine("3: Get Highest");
            Console.WriteLine("4: Product Reorder");
            Console.WriteLine("5: Get Tax");
            Console.WriteLine("6:exit");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }
        public void addproductui()
        {
            Console.WriteLine("Enter Product Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Category");
            string category = Console.ReadLine();
            Console.WriteLine("Enter Product Price");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Stock");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product MinStock");
            int minstock = Convert.ToInt32(Console.ReadLine());
            
            Product product=new Product(name, category, price, stock, minstock);
            productbl.addProduct(product);


        }
        public void showproductsui()
        {
            productbl.showProduct();
        }
        public void gethighestpriceui()
        {
            Console.WriteLine(  productbl.gethighestprice());
        }
        public void productreorderui()
        {
            productbl.productreorder();
        }
        public void gettaxui()
        {
            productbl.gettax();
        }

    }
}
