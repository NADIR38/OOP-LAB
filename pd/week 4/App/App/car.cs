using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class car
    {
        public string carname;
        public float rate;
        public string color;
        public string model;
        static List<car> cars = new List<car>();

        public car(string carname, float rate, string color, string model)
        {
            this.carname = carname;
            this.rate = rate;
            this.color = color;
            this.model = model;
        }

        public  static string addcar(car car)
        {
            cars.Add(car);
            return $"{car.carname} is added succesfully";
        }
        public static string updatecar(string carname, string newname, float newrate, string newcolor)
        {
            foreach (var car in cars)
            {
                if (car.carname == carname)
                {
                    car.carname = newname;
                    car.rate = newrate;
                    car.color = newcolor;
                    return "car is updated succesfully";

                }
            }
            return "car not found";

        }
        public static string searchcar(string carname)
        {
            foreach (var car in cars)
            {
                if (car.carname == carname)
                {
                    return $"{car.carname},is available at{car.rate}";
                }
            }
            return "car not found";
        }
        public static string DeleteCar(string name)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].carname == name)
                {
                    cars.RemoveAt(i);
                    return "Car deleted successfully";
                }
            }
            return "Car not found";
        }
        public static void ShowCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available.");
                return;
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| Car Name       | Rate      | Color    | Model  |");
            Console.WriteLine("--------------------------------------------------");

            foreach (var car in cars)
            {
                Console.WriteLine($"| {car.carname,-14} | {car.rate,-9} | {car.color,-8} | {car.model,-6} |");
            }

            Console.WriteLine("--------------------------------------------------");
        }
        public static float calculatecost(string carname, float hours)
        {
            foreach (var car in cars)
            {
                if (car.carname == carname)
                {
                    return car.rate * hours;
                }

            }
            return 0;
        }
        public static  void sortcar()
        {

            for (int i = 0; i < cars.Count - 1; i++)
            {
                for (int j = 0; j < cars.Count - 1; i++)
                {
                    if (cars[j].rate > cars[j + 1].rate)
                    {
                        car temp = cars[j];
                        cars[j] = cars[j + 1];
                        cars[j + 1] = temp;
                    }
                }
            }
            
            Console.WriteLine("car sorted succesfully");

        }
    }
}
