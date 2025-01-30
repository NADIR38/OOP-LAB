using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class transcation
    {
       public int transcation_ID;
        public string productname;
       public float amount;
        public string timestamp;
        public transcation(int ID, string Productname, float Amount, string Timestamp)
        {
            transcation_ID = ID;
           productname = Productname;
            amount = Amount;
            timestamp = Timestamp;
        }

        public transcation(transcation other)
        {
            transcation_ID = other.transcation_ID;
            productname = other.productname;
            amount = other.amount;
            timestamp = other.timestamp;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {transcation_ID}");
            Console.WriteLine($"Product: {productname}");
            Console.WriteLine($"Amount: {amount:C}");
            Console.WriteLine($"Date and time: {timestamp}");
        }

    }
}
