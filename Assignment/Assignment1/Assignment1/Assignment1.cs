using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Assignment1
    {
        static void Equalnumbers()
        {

            Console.WriteLine("Enter the 1st Number:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the 2nd Number:");
            int num2 = int.Parse(Console.ReadLine());
            if (num1 == num2)
                Console.WriteLine("Two Numbers are equal");
            else
                Console.WriteLine("Two Numbers are not equal");
        }



        //To check whether the given input is Positive  or negative Integer
        static void posnumbers()
        {
            Console.WriteLine("Enter the number:");
            int num = int.Parse(Console.ReadLine());

            if (num < 0)
                Console.WriteLine("Negative Number");
            else if (num == 0)
                Console.WriteLine("Neutral Number");
            else
                Console.WriteLine("Positive Number");
        }


        //To Perform Mathematical Operations
        static void operations()
        {
            Console.WriteLine("Enter First Number");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Which Operation to be done");
            char operation = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second Number");
            int n2 = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case '+':
                    Console.WriteLine($"{n1}+{n2}={n1 + n2}");
                    break;
                case '-':
                    Console.WriteLine($"{n1}-{n2}={n1 - n2}");
                    break;
                case '*':
                    Console.WriteLine($"{n1}*{n2}={n1 * n2}");
                    break;
                case '/':
                    if (n2 != 0)
                        Console.WriteLine($"{n1}/{n2}={n1 / n2}");
                    else
                        Console.WriteLine("Invalid");
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }


        //Multiplication Table of a number

        static void Multiplicationtable()
        {
            Console.WriteLine("Enter The Input:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{number}*{i} ={number * i}");
            }
        }

        //Sum of two given integers.if two values are same,return the triple of their sum

        static void Triple()
        {
            Console.WriteLine("Enter the First number:");
            int no1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Second number");
            int no2 = int.Parse(Console.ReadLine());
            int Sum;
            Sum = no1 + no2;
            if (no1 == no2)
            {
                Console.WriteLine(Sum * 3);
            }
            else
            {
                Console.WriteLine(Sum);
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("To check the Number is Equal or not");
            Equalnumbers();

            Console.WriteLine("Positive or Negative Number");
            posnumbers();

            Console.WriteLine("To Perform Mathematical Operation");
            operations();

            Console.WriteLine("Multiplication Table of a Number:");
            Multiplicationtable();

            Console.WriteLine("Triple Sum of the Same Number");
            Triple();


            Console.Read();
        }
    }
}
