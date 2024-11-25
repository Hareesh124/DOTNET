using System;
using TravelConcessionLibrary;

namespace TravelConcessionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            string ages = Console.ReadLine();
            if (int.TryParse(ages, out int age))
            {
                ConcessionCalculator calculator = new ConcessionCalculator();

                calculator.CalculateConcession(name, age);
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }

            Console.Read();
        }
    }
}
