using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            transcation original = new transcation(1, "apple", 20.0f,"12-02-2024 12:00:00");
            transcation copy = new transcation(original);
            original.DisplayDetails();
            copy.DisplayDetails();
            original.transcation_ID = 12;
            original.productname = "banana";
            original.amount = 200.0f;
            original.timestamp= "14-02-2024 13:00:00";
            copy.transcation_ID=15;
            copy.productname = "orange";
            copy.amount = 120.0f;
            copy.timestamp = "15-02-2024 11:00:00";
            original.DisplayDetails();
            Console.WriteLine("copied transactions");
            copy.DisplayDetails();

        }
    }
}
