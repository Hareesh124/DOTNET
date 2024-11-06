using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Distance
    {
        public int dist;
        public string distinkm;

        //operator '+' is overloaded
        public static Distance operator +(Distance d1, Distance d2)
        {
            Distance temp = new Distance();
            temp.dist = d1.dist + d2.dist;
            return temp;
        }
        public static Distance operator -(Distance d1, Distance d2)
        {
            Distance temp = new Distance();
            temp.dist = d1.dist - d2.dist;
            return temp;
        }
        public static Distance operator ++(Distance d3)
        {
            d3.dist++;
            return d3;
        }
    }
    class Operator_Overloading
    {
        static void Main()
        {
            int a = 5, b = 10, c = 0;
            c = a + b;
            c++;
            //Console.WriteLine(c);
            //Console.WriteLine("---------------");
            Distance d1, d2, d3;
            d1 = new Distance();
            d1.dist = 20;
            d2 = new Distance();
            d2.dist = 10;
            d3 = new Distance();
            d3 = d1 + d2;
            Console.WriteLine("Addition : {0}", d3.dist);
            d3 = d1 - d2;
            Console.WriteLine("Subtraction : {0}",d3.dist);
            d3.dist = 30;
            d3++;
            Console.WriteLine("The Incremented Distance is {0}", d3.dist);
            Console.Read();
        }
    }
}

