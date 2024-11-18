using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_inheritance
{
    class Student
    {
        public int RollNo { get;  set; }
        public string Name { get;  set; }
        public string Class { get;  set; }
        public string Semester { get;  set; }
        public string Branch { get;  set; }
        private int[] Marks = new int[5];

        public Student(int rollNo, string name, string studentClass, string semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            Class = studentClass;
            Semester = semester;
            Branch = branch;
        }

        public void GetMarks()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                Marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool failed = false;

            foreach (int mark in Marks)
            {
                total += mark;
                if (mark < 35)
                {
                    Console.WriteLine("Result: Failed (One or more subjects have marks less than 35)");
                    failed = true;
                    break;
                }
            }

            if (!failed)
            {
                double average = total / 5.0;
                if (average < 50)
                {
                    Console.WriteLine("Result: Failed (Average marks are less than 50)");
                }
                else
                {
                    Console.WriteLine("Result: Passed");
                }
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Roll No: {RollNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch: {Branch}");
            Console.WriteLine("Marks: " + string.Join(", ", Marks));
        }
        static void Main()
        {
            Console.Write("Enter Roll Number: ");
            int rollNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string studentClass = Console.ReadLine();

            Console.Write("Enter Semester: ");
            string semester = Console.ReadLine();

            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();

            Student student = new Student(rollNo, name, studentClass, semester, branch);

            // Get marks for 5 subjects
            student.GetMarks();

            student.DisplayData();
            student.DisplayResult();
            Console.Read();
        }
    }
}
