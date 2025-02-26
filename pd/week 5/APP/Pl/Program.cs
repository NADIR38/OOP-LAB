using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP
{
    class Program
    {
        DatabaseHelper dbHelper=new DatabaseHelper();
        static void Main(string[] args)
        {
            while (true)
            {
             
                int choice = loginmenu();
                if (choice == 1)
                {
                    Console.WriteLine("enter username");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter password");
                    string password = Console.ReadLine();
                    bool isvalid = Bl.userbl.validateuser(name, password);
                    if (isvalid)
                    {
                        while (true)
                        {
                            int userchoice =Pl. userui.usermenu();
                            if (userchoice == 1)
                            {
                                Bl.carbl.showcars();
                            }
                            else if (userchoice == 2)
                            {
                               Pl. userui.searchcarui();
                            }
                            else if (userchoice == 3)
                            {
                               Pl. userui.rentcarui();
                            }
                            else if (userchoice == 4)
                            {
                                break;
                            }
                        }
                    }
                    if(name=="nadir"&& password == "123")
                    {
                        while (true)
                        {
                            int adminchoice = Pl.Adminui.adminmenu();
                            if (adminchoice == 1)
                            {
                                Pl.Adminui.addcarui();
                            }
                            else if (adminchoice == 2)
                            {
                                Bl.carbl.showcars();
                            }
                            else if (adminchoice == 3)
                            {
                                Pl.Adminui.deletecarui();
                            }
                            else if (adminchoice == 4)
                            {
                                Pl.Adminui.updatecarui();
                            }
                            else if (adminchoice == 5)
                            {
                                Bl.carbl.sort();
                            }
                            else if (adminchoice == 6)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid user");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("enter username");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter password");
                    string password = Console.ReadLine();
                    Console.WriteLine("enter email");
                    string email = Console.ReadLine();
                    models.user user = new models.user(name, password,email);
                    
                    Bl.userbl.adduser(user);
                  

                }
                else if (choice == 3)
                {
                    break;

                }
            }
        }
        public static int loginmenu()
        {
            Console.WriteLine("1:Sign in");
            Console.WriteLine("2:Sign up");
            Console.WriteLine("3:exit");
            Console.WriteLine("enter your choice");
            int choice = int.Parse(Console.ReadLine());
            return choice;

        }
    }
}
