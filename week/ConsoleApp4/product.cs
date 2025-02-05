using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public  class product
    {
        public int id;
        public string name;
        public string brand;
        public string category;
        public string country;
        public float price;
        public product(int ID,string sname,string brandname,string Category,string Country,float Price) 
        { 
        id= ID;
            name= sname;
            brand= brandname;
            category= Category;
            country= Country;
                country= Country;
            price= Price;
        }
       
    }

}
