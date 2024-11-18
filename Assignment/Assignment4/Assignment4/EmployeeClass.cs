using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Employee
    {
        int empId;
        string empName;
        double salary;

        public Employee(int empId, string empName, double salary)
        {
            this.empId = empId;
            this.empName = empName;
            this.salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"Employee ID: {empId}, Name: {empName}, Salary: {salary}");
        }
    }
    public class PartTimeEmployee : Employee
    {
        double wages;

        public PartTimeEmployee(int empId, string empName, double salary, double wages) : base(empId, empName, salary)
        {
            this.wages = wages;
        }

        public new void Display()
        {
            base.Display();
            Console.WriteLine("Wages: " + wages);
        }
    }

    public class EmployeeClass
    {
        public static void Main(string[] args)
        {
            PartTimeEmployee partTimeEmp = new PartTimeEmployee(1, "Hareesh", 2000, 500);
            partTimeEmp.Display();
            Console.Read();
        }
    }
}
