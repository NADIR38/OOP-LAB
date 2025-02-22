using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale.models
{
    public class Product
    {
        public string name;
        public string category;
        public float price;
        public int stock;
        public int minstock;
        public float tax;

        public Product(string name, string category, float price, int stock, int minstock,float tax=0)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.stock = stock;
            this.minstock = minstock;
            tax = 0;

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
    }
    }
