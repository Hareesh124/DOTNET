using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_on
{
    class EmptyException : Exception
    {
        public EmptyException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                if (name == "")
                {
                    throw new EmptyException("Name cannot be empty. Please enter a valid name.");
                }

                string upperName = name.ToUpper();
                Console.WriteLine("Your name in uppercase is: " + upperName);
            }
            catch (EmptyException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.Read();
        }
    }
}
