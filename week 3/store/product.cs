using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
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
        public float tax()
        {
if(category=="groceries")
            {
                return price * 0.10f;
            }
else if(category=="fruits")
            {
                return price * 0.05f;
            }
            return price * 0.15f;
        }
        public bool reorder()
        {
            return quantity<remainingquantity;
        }

    }
}
