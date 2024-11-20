using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRev
{
    // Delegate declaration

    public delegate int MyDelegate(int num1, int num2);

    // Method that matches the delegate signature
    public class MathOperations
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }
    }

    // Usage
    class Program
    {
        static void Main()
        {
            // Create a delegate instance
            MyDelegate addDelegate = new MyDelegate(MathOperations.Add);

            // Call the method through the delegate
            int result = addDelegate(5, 10); // Output: 15
            Console.WriteLine(result);

            // Change delegate to point to another method
            addDelegate = new MyDelegate(MathOperations.Multiply);
            result = addDelegate(5, 10); // Output: 50
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
