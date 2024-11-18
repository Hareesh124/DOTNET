using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_on
{
    internal class Icomp
        {
            static void Main()
            {
                List<Employee> emplist = new List<Employee>
            {
                new Employee(200, "Nikhil", 50000, "Infinite"),
                new Employee(130, "Navya", 52000, "Infinite"),
                new Employee(250, "Sahana", 48000, "Infinite"),
                new Employee(150, "Rajesh", 50000, "Infinite")
            };

            emplist.Sort();

            Console.WriteLine("---------Sorted by EmpId----------");
            foreach (Employee e in emplist)
            {
                Console.WriteLine(e);
            }

            emplist.Sort(new EmployeeNameComparer());

            Console.WriteLine("---------Sorted by Employee Name----------");
            foreach (Employee e in emplist)
            {
                Console.WriteLine(e);
            }

            Console.Read();

            }
            class Employee : IComparable<Employee>
            {
                int Empid;
                public string EmpName;
                public float Salary;
                string Company;

                public Employee(int id, string name, float sal, string comp)
                {
                    Empid = id;
                    EmpName = name;
                    Salary = sal;
                    Company = comp;
                }

                public override string ToString()
                {
                    return String.Format("Employee Named : " + EmpName + "  with Id : " + Empid + " Works for " + Company + " and Earns Rs. :" + Salary);
                }

                public int CompareTo(Employee other)
                {
                    return this.Empid.CompareTo(other.Empid);
                }
            }

            class EmployeeNameComparer : IComparer<Employee>
            {
                 public int Compare(Employee x, Employee y)
                 {
                        return x.EmpName.CompareTo(y.EmpName);
                 }
            }
    }
}
