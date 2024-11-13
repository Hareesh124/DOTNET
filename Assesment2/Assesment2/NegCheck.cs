using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment2
{
   
        public class NegativeNumberException : Exception
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        class NegCheck
        {
            public static void CheckNumber(int num)
            {
                if (num < 0)
                {
                    throw new NegativeNumberException("The number cannot be negative.");
                }
                else
                {
                    Console.WriteLine($"The number {num} is valid.");
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Enter an integer:");

                try
                {
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    CheckNumber(userInput);
                }
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.Read();
            }
        }
    
}
