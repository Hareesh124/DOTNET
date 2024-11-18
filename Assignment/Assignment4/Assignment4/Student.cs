using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        void ShowDetails();
    }
    public class Dayscholar : IStudent
    {
        public int StudentId { get; private set; }
        public string Name { get; private set; }

        public Dayscholar(int studentId, string name)
        {
            StudentId = studentId;
            Name = name;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar Student ID: {StudentId}, Name: {Name}");
        }
    }
    public class Resident : IStudent
    {
        public int StudentId { get; private set; }
        public string Name { get; private set; }

        public Resident(int studentId, string name)
        {
            StudentId = studentId;
            Name = name;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident Student ID: {StudentId}, Name: {Name}");
        }
    }

    public class Student
    {
        public static void Main(string[] args)
        {
            IStudent student1 = new Dayscholar(10, "Hareesh");
            IStudent student2 = new Resident(11, "Anand");
            student1.ShowDetails();
            student2.ShowDetails();
            Console.Read();
        }
    }
}
