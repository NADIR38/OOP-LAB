using point_of_sale.Bl;
using point_of_sale.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale
{
    class Program
    {
        static void Main(string[] args)
        {
            customerbl customerbl = new customerbl();
            productbl productbl = new productbl();
            pl.adminui adminui = new pl.adminui();
            pl.customerui customerui = new pl.customerui();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Departmental Store Management System =====");
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("===== Sign In =====");
                        Console.Write("Enter your name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string pass = Console.ReadLine();

                        if (name == "nadir" && pass == "123")
                        {
                            while (true)
                            {
                                Console.Clear();
                                int choices = pl.adminui.adminmenu();
                                switch (choices)
                                {
                                    case 1:
                                        adminui.addproductui();
                                        break;
                                    case 2:
                                        adminui.showproductsui();
                                        break;
                                    case 3:
                                        adminui.gethighestpriceui();
                                        break;
                                    case 4:
                                        adminui.productreorderui();
                                        break;
                                    case 5:
                                        adminui.gettaxui();
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 6:
                                        Console.WriteLine("Logging out... Press any key to return to the main menu.");
                                        Console.ReadKey();
                                        break;  
                                    default:
                                        Console.WriteLine("Invalid choice! Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                }
                                if (choices == 6) 
                                    break;  
                            }
                        }
                        else if (customerbl.validatecus(name, pass) == true)
                        {
                            while (true)
                            {
                                Console.Clear();
                                int option = pl.customerui.customermenu();
                                switch (option)
                                {
                                    case 1:
                                        customerui.showproductui();
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        customerui.buyproductui();
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        customerui.invoiceui();
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        customerbl.viewprofile(dal.customerdl.customers.Find(x => x.cus_name == name));
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Console.WriteLine("Logging out... Press any key to return to the main menu.");
                                        Console.ReadKey();
                                        break; 
                                    default:
                                        Console.WriteLine("Invalid choice! Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                }
                                if (option == 5)
                                    break;  
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials! Press any key to return to the main menu...");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("===== Sign Up =====");
                        Console.Write("Enter your name: ");
                        string cus_name = Console.ReadLine();
                        Console.Write("Enter your email: ");
                        string cus_email = Console.ReadLine();
                        Console.Write("Enter your phone: ");
                        string cus_phone = Console.ReadLine();
                        Console.Write("Enter your address: ");
                        string cus_address = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string cus_pass = Console.ReadLine();

                        customerbl.addcustomer(new customer(cus_name,cus_pass, cus_email, cus_phone, cus_address));

                        Console.WriteLine("Registration successful! Press any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Exiting... Press any key to close.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
