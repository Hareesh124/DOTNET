using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            Aggregates_General();
            Seed_Aggregate();
            Console.WriteLine("------------------------");
            Element_At();
            Console.Read();
        }

        

        //aggregates
        public static void Aggregates_General()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sum = numbers.Max();
            Console.WriteLine(sum);
        }

        //aggreagtion
        public static void Seed_Aggregate()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sum is {0}", numbers.Sum());// 15
            var res = numbers.Aggregate(10, (a, b) => a + b); // 25
            Console.WriteLine("Aggregates sym with seed : {0}",res);


            res = numbers.Aggregate((a, b) => a * b);// 120

            Console.WriteLine("Just aggregate is {0}",res);

        }

        static void Element_At()
        {
            string[] fruits = { "Apple", "Oranges", "Kiwi", "Banana", "Grapes" };

            var result = fruits.ElementAt(3);
            Console.WriteLine(result);
            result = fruits.ElementAt(5);
        }



    }
}
