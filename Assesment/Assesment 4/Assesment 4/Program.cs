using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
}

internal class Program
{
    public static void Main()
    {
        List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager",City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate",City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", City = "Pune" }
        };

        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        var allemp = from emp in empList select emp;
        Console.WriteLine("All Employees:");
        Console.WriteLine("--------------");

        foreach (var emp in allemp)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        var notmum = from emp in empList
                     where emp.City != "Mumbai"
                     select emp;
        Console.WriteLine("Employees whose location is not Mumbai:");
        Console.WriteLine("----------------------------------------");
        foreach (var emp in notmum)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }


        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        var asstmgr = from emp in empList
                      where emp.Title == "AsstManager"
                      select emp;

        Console.WriteLine("Employees whose title is AsstManager:");
        Console.WriteLine("-------------------------------------");

        foreach (var emp in asstmgr)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        Console.WriteLine();

        var lname = from emp in empList
                    where emp.LastName.StartsWith("S")
                    select emp;
        Console.WriteLine("Employees whose Last Name starts with 'S':");
        Console.WriteLine("-------------------------------------------");

        foreach (var emp in lname)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
        }
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        Console.Read();
    }
}

