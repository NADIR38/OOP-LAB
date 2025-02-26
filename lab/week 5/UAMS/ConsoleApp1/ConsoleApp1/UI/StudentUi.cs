using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.UI
{
    internal class StudentUI
    {
        public static BL.StudentBL TakeInputForStudent()
        {
            string Name;
            int Age;
            double FSCMarks;
            double EcatMarks;
            List<BL.DegreeProgramBL> Preferences = new List<BL.DegreeProgramBL>();
            Console.Write("Enter Student Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSc Marks: ");
            FSCMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat Marks: ");
            EcatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");
            UI.DegreeUI.ViewDegreePrograms();

            Console.Write("Enter how many preferences to Enter: ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (BL.DegreeProgramBL dp in DL.DegreeProgramDL.ProgramList)
                {
                    if (degName == dp.degreeName && !(Preferences.Contains(dp)))
                    {
                        Preferences.Add(dp);
                        flag = true;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    x--;
                }
            }

            BL.StudentBL s = new BL.StudentBL(Name, Age, FSCMarks, EcatMarks, Preferences);
            return s;
        }

        public static void PrintStduents()
        {
            foreach (BL.StudentBL s in DL.StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got Admission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not get Admission");
                }
            }
        }

        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (BL.StudentBL s in DL.StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }

        public static string TakeName()
        {
            Console.Write("Enter the Student Name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static void CalculateFeeForAll()
        {
            foreach (BL.StudentBL s in DL.StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has " + s.CalculateFee() + " fees");
                }
            }
        }

        public static void ViewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (BL.StudentBL s in DL.StudentDL.StudentList)
            {
                if (s.regDegree != null)
                {
                    if (degName == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                    }
                }
            }
        }
    }
}