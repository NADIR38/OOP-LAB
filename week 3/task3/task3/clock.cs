using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class clockType
    {
        public int hours;
        public int minutes;
        public int seconds;


        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        
        }
        public clockType(int h)
        {
            hours = h;
        }
        public clockType(int h, int m)
        {
            hours = h; minutes = m;
        }
        public clockType(int h, int m, int s)
        {
            hours = h; minutes = m; seconds = s;
        }
        public void twoClocks(clockType cl)
        {
            Console.Write((cl.hours - hours) + ":");
            Console.Write((cl.minutes - minutes) + ":");
            Console.Write((cl.seconds - seconds) + ":");
        }
        public void incrementSecond()
        {
            seconds++;
        }
        public void incrementMinute()
        {
            minutes++;
        }
        public void incrementHour()
        {
            hours++;
        }
        public void printTime()
        {
            Console.WriteLine(hours + " " + minutes + " " + seconds);
        }
        public bool isEqual(int h, int m, int s)
        {
            if (hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual(clockType temp)
        {
            if (hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
            {
                return true;
            }
            else

            {
                return false;
            }
        } 
        public void elapsedtime()
        {
            Console.WriteLine(DateTime.Now);
            DateTime currenttime= DateTime.Now;
            DateTime start = DateTime.Today;
            TimeSpan elapsed=currenttime - start;
            Console.WriteLine(elapsed);
         
            
        }
        public void remainingtime()
        {
            DateTime currenttime = DateTime.Now;
            TimeSpan fullday = new TimeSpan(24, 0, 0);
            TimeSpan remaining = fullday - currenttime.TimeOfDay;
            Console.WriteLine(remaining);   

        }
    }
}
