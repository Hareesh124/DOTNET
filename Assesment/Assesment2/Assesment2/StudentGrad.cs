using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment2
{
    public abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public abstract bool IsPassed(double grade);
    }

    public class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }


    public class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
            : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class StudentGrad
    {
        static void Main()
        {

            Console.WriteLine("Enter details for an Undergraduate student:");
            Console.WriteLine("Name: ");
            string undergradName = Console.ReadLine();
            Console.WriteLine("Student ID: ");
            int undergradId = int.Parse(Console.ReadLine());
            Console.WriteLine("Grade: ");
            double undergradGrade = double.Parse(Console.ReadLine());

            Undergraduate undergrad = new Undergraduate(undergradName, undergradId, undergradGrade);
            Console.WriteLine("\nEnter details for a Graduate student:");
            Console.WriteLine("Name: ");
            string gradName = Console.ReadLine();
            Console.WriteLine("Student ID: ");
            int gradId = int.Parse(Console.ReadLine());
            Console.WriteLine("Grade: ");
            double gradGrade = double.Parse(Console.ReadLine());

            Graduate grad = new Graduate(gradName, gradId, gradGrade);
            Console.WriteLine($"\n{undergrad.Name} whose ID is {undergrad.StudentId} has passed: {undergrad.IsPassed(undergrad.Grade)}");
            Console.WriteLine($"{grad.Name} whose ID is {grad.StudentId}) has passed: {grad.IsPassed(grad.Grade)}");
            Console.Read();
        }
    }

}
