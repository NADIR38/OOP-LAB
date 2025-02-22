using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int choice = loginmenu();

                if (choice == 3) // Exit option
                    break;

                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter role:");
                    string role = Console.ReadLine();
                    User u1 = new User(name, password, role);
                    Console.WriteLine(u1.adduser(u1));
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter name:");
                    string names = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string passwords = Console.ReadLine();
                    User existinguser = User.validateuser(names, passwords);

                    if (existinguser.roles == "admin")
                    {
                        while (true)
                        {
                            Console.Clear();
                            int choices = adminmenu();

                            if (choices == 6) // Exit option for admin
                                break;

                            switch (choices)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Enter car name:");
                                    string carname = Console.ReadLine();
                                    Console.WriteLine("Enter car rate:");
                                    float rate = float.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter car color:");
                                    string color = Console.ReadLine();
                                    Console.WriteLine("Enter car model:");
                                    string model = Console.ReadLine();
                                    car c1 = new car(carname, rate, color, model);
                                    Console.WriteLine(car.addcar(c1));
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    car.ShowCars();
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Enter car name to update:");
                                    string car_name = Console.ReadLine();
                                    Console.WriteLine("Enter new car name:");
                                    string newcarname = Console.ReadLine();
                                    Console.WriteLine("Enter new rate:");
                                    float newrate = float.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter new color:");
                                    string newcolor = Console.ReadLine();
                                    Console.WriteLine(car.updatecar(car_name, newcarname, newrate, newcolor));
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Enter car name to delete:");
                                    string dcar = Console.ReadLine();
                                    Console.WriteLine(car.DeleteCar(dcar));
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Console.Clear();
                                    car.sortcar();
                                    Console.ReadKey();
                                    break;
                            }
                        }
                    }
                    else if (existinguser.roles == "user")
                    {
                        while (true)
                        {
                            Console.Clear();
                            int option = UserMenu();

                            if (option == 4)
                                break;

                            switch (option)
                            {
                                case 1:
                                    Console.Clear();
                                    car.ShowCars();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Enter car name to search:");
                                    string cname = Console.ReadLine();
                                    Console.WriteLine(car.searchcar(cname));
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Enter car name to rent:");
                                    string rname = Console.ReadLine();
                                    Console.WriteLine("Enter hours:");
                                    float hours = float.Parse(Console.ReadLine());
                                    float totalCost = car.calculatecost(rname, hours);
                                    Console.WriteLine($"Your total cost for the car is {totalCost}");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        static int loginmenu()
        {
            Console.Clear();
            Console.WriteLine("_____________ LOGIN MENU _______________");
            Console.WriteLine("1: Sign Up");
            Console.WriteLine("2: Sign In");
            Console.WriteLine("3: Exit");
            return int.Parse(Console.ReadLine());
        }

        static int adminmenu()
        {
            Console.Clear();
            Console.WriteLine("_____________ ADMIN MENU _______________");
            Console.WriteLine("1: Add a Car");
            Console.WriteLine("2: Show Cars");
            Console.WriteLine("3: Update Car Data");
            Console.WriteLine("4: Delete a Car");
            Console.WriteLine("5: Sort Cars by Rate");
            Console.WriteLine("6: Exit");
            return int.Parse(Console.ReadLine());
        }

        static int UserMenu()
        {
            Console.Clear();
            Console.WriteLine("_____________ USER MENU _______________");
            Console.WriteLine("1: Show Cars");
            Console.WriteLine("2: Search a Car");
            Console.WriteLine("3: Rent a Car");
            Console.WriteLine("4: Exit");
            return int.Parse(Console.ReadLine());
        }
    }
}
