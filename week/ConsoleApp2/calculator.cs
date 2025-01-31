using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public  class calculator
    {
        public calculator()
        { 
        }
        public float add(int x,int y) 
        {
        return x + y;
        }
        public float subtract(int x, int y) 
        {
        return x - y;
        }
        public float multiply(int x, int y)
        { 
        return x * y;   
        }
        public float divide(int x, int y) 
        {
            if (y == 0)
            {
                Console.WriteLine("numbers not divisble");
                return 0;
            }
            else
            {
                return x / y;
            }
        }

    }
}
