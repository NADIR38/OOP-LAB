using APP.Bl;
using System;

namespace APP.Pl
{
    public  class Adminui
    {
        public static int adminmenu()
        {
            Console.WriteLine("1.add car");
            Console.WriteLine("2.show cars");
            Console.WriteLine("3.delete car");
            Console.WriteLine("4.update car");
            Console.WriteLine("5.sort cars");
            Console.WriteLine("6.exit");
            Console.WriteLine("enter your choice");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void addcarui()
        {
            Console.WriteLine("enter car name");
            string name = Console.ReadLine();
            Console.WriteLine("enter car color");
            string color = Console.ReadLine();
            Console.WriteLine("enter car rate");
            float rate = float.Parse(Console.ReadLine());
            Console.WriteLine("enter car model");
            string model = Console.ReadLine();
            models.car car = new models.car(name, model, color, rate);
             carbl.addcar(car);
        }
        public static void updatecarui()
        {
            Console.WriteLine("enter car name");
            string name = Console.ReadLine();
            Console.WriteLine("enter new car name");
            string new_name = Console.ReadLine();
            Console.WriteLine("enter new car color");
            string new_color = Console.ReadLine();
            Console.WriteLine("enter new car rate");
            float new_rate = float.Parse(Console.ReadLine());
            Console.WriteLine("enter new car model");
            string new_model = Console.ReadLine();
            bool isupadted = Bl.carbl.updatecar(name, new_name, new_rate, new_color, new_model);
            if (isupadted)
            {
                Console.WriteLine("car updated succesfully");
            }
            else
            {
                Console.WriteLine("car not found");
            }
        }
        public static void deletecarui()
        {
            Console.WriteLine("Enter car name to delete");
            string dname = Console.ReadLine();
            bool isdeleted = Bl.carbl.deletecar(dname);
            if (isdeleted == true)
            {
                Console.WriteLine("car deleted succesfully");
                Bl.carbl.showcars();
            }
            else
            {
                Console.WriteLine("car not found");
            }
        }


    }
}
