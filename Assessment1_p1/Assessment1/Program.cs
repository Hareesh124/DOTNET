using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Program
    {
         static void Main(string[] args)
            {
                int n;
                string inp;
                Console.WriteLine("Enter the string : ");
                inp = Console.ReadLine();
                Console.WriteLine("Enter the index to be removed : ");
                n = int.Parse(Console.ReadLine());
                if (n >= 0 && n < inp.Length)
                {
                    inp = inp.Remove(n, 1);
                    Console.WriteLine(inp);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                    Console.WriteLine(inp);
                }

                Console.Read();

            }

        }
}
