using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public  class atm
    {
        public float balance;
        public List<string> transaction;
        public atm(float Balance)
        {
            balance = Balance;
            transaction = new List<string>();

        }
        public float Amount()

        {
            return balance;
        }
        public void deposit(float amount)
        {
            balance += amount;
            transaction.Add($"{DateTime.Now} - deposited {amount}");
            Console.WriteLine($"Deposited:{amount}");
            Console.WriteLine($"total balance:{balance}");
        }
        public void withdraw(float amount)
        {
            if (balance < 0 || amount > balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                balance -= amount;
                transaction.Add($"{DateTime.Now} - withdrawn {amount}");

                Console.WriteLine($"Withdrawn amount:{amount}");
                Console.WriteLine($"remaining balance balance:{balance}");

            }

        }
        public void transactions()
        {
            foreach (var transaction in transaction) 
                {
                Console.WriteLine(transaction);
                }
        }

    }
}
  
