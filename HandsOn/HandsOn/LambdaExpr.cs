using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn
{
    class LambdaExpr
    {
        static void Main(string[] args)
        {                                    //List initilaization
            List<int> numbers = new List<int>() { 36, 71, 12, 15, 29, 18, 27, 17, 9, 34 };

            foreach (var value in numbers)
            {
                Console.WriteLine("{0} ", value);
            }

            //using lambda expressions to find the square of all numbers in the List
            var square = numbers.Select(x => x * x);

            Console.WriteLine("-----Squares of Numbers------");
            foreach (int v in square)
            {
                Console.Write("{0} ", v);
            }

            //find all the numbers divisible by 3 in the list
            var divby3 = numbers.Select(x => x % 3 == 0);
            foreach(var val in divby3)
            {
                Console.Write("{0} ", val);
            }
            Console.Read();
        }
    }
}
