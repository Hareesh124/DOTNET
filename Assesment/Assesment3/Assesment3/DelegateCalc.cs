using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment3
{

    class DelegateCalc
    {
        public delegate int Calculator(int a, int b);

        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static void Main(string[] args)
        {
            
            Console.Write("Enter the first integer: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second integer: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Calculator calcAdd = Add;
            
            Console.WriteLine($"Addition: {calcAdd(num1, num2)}");

            calcAdd += Subtract;
            Console.WriteLine($"Subtraction: {calcAdd(num1, num2)}");

            calcAdd += Multiply;
            Console.WriteLine($"Multiplication: {calcAdd(num1, num2)}");
           
            Console.Read();
        }
    }
}
