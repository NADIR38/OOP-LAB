using APP.Dl;
using APP.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Bl
{
    public class carbl
    {
        public static void addcar(models.car car)
        {
            Dl.cardl.cars.Add(car);
            Console.WriteLine("car added succesfully");

        }
        public static void showcars()
        {
            foreach(var item in cardl.cars)
            {
                Console.WriteLine($"car name:{item.car_name}");
                Console.WriteLine($"car color:{item.car_color}");
                Console.WriteLine($"car rate:{item.price}");
                Console.WriteLine($"car model:{item.car_model}");



            }
        }
        public static bool deletecar(string name)
        {
            for(int i=0;i<cardl.cars.Count;i++)
            {
                if (name == cardl.cars[i].car_name)
                {
                    cardl.cars.RemoveAt(i);
                    return true;

                }
            }
            return false;
        }
        public static bool updatecar(string name,string new_name,float new_rate,string new_color,string new_model)
        {
            foreach(var item in cardl.cars)
            {
                if(item.car_name==name)
                {
                    item.car_name = new_name;
                    item.price = new_rate;
                    item.car_color = new_color;
                    item.car_model = new_model;
                    return true;

                }
            }
            return false;
        }
       public static void sort()
        {
            for(int i=0;i<cardl.cars.Count;i++)
            {
                for(int j=0;j<cardl.cars.Count;j++)
                {
                    if (cardl.cars[j].price < cardl.cars[j=1].price)
                    {
                        car temp = cardl.cars[j + 1];
                        cardl.cars[j + 1] = cardl.cars[j];
                        cardl.cars[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("car sorted succesfully");
        }
    }
}
