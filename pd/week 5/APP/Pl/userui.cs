using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Pl
{
   public  class userui
    {
        public static int usermenu()
        {
            Console.WriteLine("1:Show cars");
            Console.WriteLine("2:Search a car");
            Console.WriteLine("3.rent car");
            Console.WriteLine("4.exit");
            Console.WriteLine("enter your choice");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void searchcarui()
        {
            Console.WriteLine("enter car name to search");
            string name = Console.ReadLine();
            bool isfound = Bl.userbl.searchcar(name);
            if (isfound)
            {
                Console.WriteLine("car found");
            }
            else
            {
                Console.WriteLine("car not found");
            }
        }
        public static void rentcarui()
        {
            Console.WriteLine("enter car name to rent");
            string name = Console.ReadLine();
            Console.WriteLine("enter hours");
            float hours = float.Parse(Console.ReadLine());
            float total = Bl.userbl.calculate_cost(name, hours);
            Console.WriteLine($"total cost is {total}");
        }
    }
}
