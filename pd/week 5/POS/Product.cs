using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
   public  class Product
    {
        public string name;
        public string category;
        public float price;
        public int stock;
        public int minstock;
        public float tax;
        
        public Product(string name, string category, float price, int stock, int minstock)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.stock = stock;
            this.minstock = minstock;
            
        }
        public bool minquan()
        {
            if (stock < minstock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public float GetSalesTax()
        {
            if (category == "grocery")
                return price * 0.10f;
            else if (category == "fruit")
                return price * 0.05f;
            else
                return price * 0.15f;
        }
        public static Product Parse(string data)
        {
            string[] parts = data.Split(',');
            return new Product(
                parts[0],
                parts[1],
                float.Parse(parts[2]),
                int.Parse(parts[3]),
                int.Parse(parts[4])
            );
        }
    }
}
