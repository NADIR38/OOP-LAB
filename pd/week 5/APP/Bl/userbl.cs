using APP.Dl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Bl
{
    public class userbl
    {
        public static void adduser(models.user user)
        {
            Dl.userdl.users.Add(user);
            Console.WriteLine("user added succesfully");
        }
        public static bool validateuser(string name, string password)
        {
            foreach (var item in Dl.userdl.users)
            {
                if (item.username == name && item.password == password)
                {
                    return true;

                }

            }
            return false;
        }
        public static bool searchcar(string cname)
        {
            foreach (var item in cardl.cars)
            {
                if (item.car_name.ToLower() == cname.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public static float calculate_cost(string name,float hours)
        {
            foreach(var item in cardl.cars)
            {
                if(item.car_name.ToLower()==name.ToLower())
                {
                    float total = item.price * hours;
                    return total;
                }
            }
            return 0;
        }
        
    }
}
