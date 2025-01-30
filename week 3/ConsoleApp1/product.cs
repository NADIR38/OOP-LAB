using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class product
    {
        public string name;
        public string category;
        public float price;
        public int quantity;
        public int remainingquantity;
        public product(string NAME, string Category, float PRICE, int QUANTITY, int minimumquantity)
        {
            name = NAME;
            category = Category;
            price = PRICE;
            quantity = QUANTITY;
            remainingquantity = minimumquantity;
        }
        public product()
        {
                name=null;
         category=null;
         price=0.0f;
        quantity=0;
         remainingquantity=0;

        }
        public product(product p)
        {
            name = p.name;
            category = p.category;
            price = p.price;
            quantity = p.quantity;
            remainingquantity = p.remainingquantity;
        }
        public float salestax()
        {
            if (category == "groceries")
            {
                return price * 0.10f;

            }
            else if (category == "fruits")
            {
                return price * 0.05f;
            }
            else
            {
                return price * 0.15f;

            }


        }
        public bool needreorder()
        {
            return quantity < remainingquantity;
        }



    }
   
}
