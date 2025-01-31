using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            atm str = new atm(10000.0f);
           
            int choice = mainmenu();
            float amount;
            while (true)
            {
                switch (choice)
                {
                    case 1:

                        Console.WriteLine($"Your balance is {str.Amount()}");

                        break;
                        case 2:
                        Console.WriteLine("enter the amount yoyu want to deposit");
                        amount=int.Parse(Console.ReadLine());
                        str.deposit(amount);
                        break;
                    case 3:
                        Console.WriteLine("enter the amount yoyu want to withdraw");
                        amount = int.Parse(Console.ReadLine());
                        str.withdraw(amount);
                        break;
                    case 4:
                        str.transactions();
                        break;
                }
                choice = mainmenu();

            }
        }
        static int mainmenu()
        {
            Console.WriteLine("ATM");
                Console.WriteLine("Check balance");
            Console.WriteLine("Deposit Amount");
            Console.WriteLine("Withdraw Amount");
            Console.WriteLine("View transcation history");
            int option=int.Parse(Console.ReadLine());
            return option;
        }
    }
}
