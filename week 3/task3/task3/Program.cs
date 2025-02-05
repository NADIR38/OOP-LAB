using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clockType empty_time=new clockType();
            Console.WriteLine("empty time:");
            empty_time.printTime();
            clockType hour_time=new clockType(8);
            Console.WriteLine("hour time:");
            hour_time.printTime();
            clockType minute_time = new clockType(8, 10);
            Console.WriteLine("minute time");
            minute_time.printTime();
            clockType full_time = new clockType(8, 10, 10);
            Console.WriteLine("full time:");
            full_time.printTime();
            full_time.incrementSecond();
            Console.WriteLine("full time(incrementSecond):");
            full_time.printTime();
            full_time.incrementMinute();
            Console.WriteLine("full time(increment Minutes):");
            full_time.printTime();
            full_time.incrementHour();
            Console.WriteLine("full time(increment hours):");
            full_time.printTime();
            bool flag=full_time.isEqual(11,1,1);
            Console.WriteLine("flag:"+ flag);
            clockType cmp=new clockType(10,12,1);
            flag = full_time.isEqual(cmp);
            Console.WriteLine("object flag :"+flag);

            clockType cl1 = new clockType(12, 45, 00);
            clockType cl2 = new clockType(11, 45, 00);
            cl1.twoClocks(cl2);
            clockType cl3 = new clockType();
            cl3.elapsedtime();
            cl3.remainingtime();


        }
    }
}
