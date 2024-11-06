using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asess1_p4
{
    internal class Program
    {
        public static int count(string str, char letter)
        {
            int count = 0;

            foreach (char c in str)
            {
                if (char.ToLower(c) == char.ToLower(letter))
                {
                    count++;
                }
            }

            return count;
        }
        static void Main(string[] args)
        {
            string s,s1;
            char c;
            Console.WriteLine("Enter the string:");
            s = Console.ReadLine();
            Console.WriteLine("Enter the character:");
            s1 = Console.ReadLine();
            c = s1[0];
            Console.WriteLine("Occurences : ");
            Console.WriteLine(count(s, c));
            Console.Read();
        }
    }
}
