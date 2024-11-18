using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1_p2
{
    internal class Program
    {

        public static string Swap(string str)
        {
            if (str.Length <= 1) return str;

            char firstChar = str[0];
            char lastChar = str[str.Length - 1];

            return lastChar + str.Substring(1, str.Length - 2) + firstChar;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("ENter the string : ");
            string input1 = Console.ReadLine();
            Console.WriteLine(Swap(input1));
            Console.Read();
        }
    }
}
