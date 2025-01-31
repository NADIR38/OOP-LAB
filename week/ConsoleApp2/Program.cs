using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        calculator calc = new calculator();
            int x, y;
            int choice = mainmenu();
            while (true)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the first number");
                        x=int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the second number");
                        y=int.Parse(Console.ReadLine());
                        Console.WriteLine($"Addition: x+y= {calc.add(x,y)}");
                        break;
                        case 2:
                        Console.WriteLine("Enter the first number");
                        x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the second number");
                        y = int.Parse(Console.ReadLine());
                        Console.WriteLine($"subtraction: x-y = {calc.subtract(x,y)}");
                        break;
                        case 3:
                        Console.WriteLine("Enter the first number");
                        x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the second number");
                        y = int.Parse(Console.ReadLine());
                        Console.WriteLine($"multiplication: x*y= {calc.multiply(x,y)}");
                        break;
                        case 4:
                        Console.WriteLine("Enter the first number");
                        x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the second number");
                        y = int.Parse(Console.ReadLine());
                        Console.WriteLine($"division: x/y = {calc.divide(x,y)}"); 
                        break;
                }
                choice = mainmenu();
            }
        }
        public static int mainmenu()
        {
            Console.WriteLine("basic calculator");

            Console.WriteLine("ADDITION");
            Console.WriteLine("subtraction");
            Console.WriteLine(("multiplication"));
            Console.WriteLine("division");
            int option;
            option=int.Parse(Console.ReadLine());
            return option;
        }
    }
}
