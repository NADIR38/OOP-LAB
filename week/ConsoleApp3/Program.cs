using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            int choice = DisplayMenu();
            while (true)
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("\nEnter student name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter matric marks: ");
                        float matric = float.Parse(Console.ReadLine());

                        Console.Write("Enter FSC marks: ");
                        float fsc = float.Parse(Console.ReadLine());

                        Console.Write("Enter ECAT marks: ");
                        float ecat = float.Parse(Console.ReadLine());

                        students.Add(new Student(name, matric, fsc, ecat));
                        Console.WriteLine("Student added successfully!");
                        break;
                    case 2:
                        Console.WriteLine("\nList of Students");
                        showstudent();
                        break;
                    case 3:
                        calculateaggregate();
                        break;
                    case 4:
                        topstudents();
                        break;
                }

                choice = DisplayMenu();
            }
        }

        static int DisplayMenu()
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Show Students");
            Console.WriteLine("3. Calculate Aggregates");
            Console.WriteLine("4. Show Top Students");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        static void calculateaggregate()
        {
            List<float> aggregates = new List<float>();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                float aggregate = student.Aggregates();
                student.aggregate = aggregate; 
                aggregates.Add(aggregate);
                Console.WriteLine($"Name: {student.Name}, Aggregate: {aggregate}");
            }
        }

        static void showstudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("List of students:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Matric Marks: {student.matricmarks}");
                Console.WriteLine($"FSc Marks: {student.fscmarks}");
                Console.WriteLine($"ECAT Marks: {student.ecatmarks}");
                Console.WriteLine($"Aggregate: {student.aggregate}");  
            }
        }

        static void topstudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                students[i].aggregate = students[i].Aggregates();
            }

            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].aggregate < students[j].aggregate)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            Console.WriteLine("Top Students:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Name} - {students[i].aggregate}");
            }
        }
    }

}
