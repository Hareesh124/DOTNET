using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asses1_p3
{
    internal class Program
    {

        static int largest(int num1, int num2, int num3)
        {
            int max = num1;
            if (num2 > max)
            {
                max = num2;
            }
            if (num3 > max)
            {
                max = num3;
            }
            return max;
        }
        static void Main(string[] args)
        {
            int n1, n2, n3;
            Console.WriteLine("Enter 3 numbers");
            n1 = int.Parse(Console.ReadLine());
            n2 = int.Parse(Console.ReadLine());
            n3 = int.Parse(Console.ReadLine());
            Console.WriteLine(largest(n1, n2, n3));
            Console.Read();
        }
    }
}
