using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Assignment2
    {
        enum daysinaweek {Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}
        static void swap()
        {

            Console.WriteLine("Enter the Value of a:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Value of b:");
            int b = int.Parse(Console.ReadLine());

            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"The Swaped Value of a is {a}");
            Console.WriteLine($"The Swaped Value of b is {b}");

        }

        static void display()
        {
            Console.WriteLine("Enter The number to be displayed:");
            int num = int.Parse(Console.ReadLine());
            Console.Write("{0} {0} {0} {0}\n", num);
            Console.Write("{0}{0}{0}{0}\n", num);
            Console.Write("{0} {0} {0} {0}\n", num);
            Console.Write("{0}{0}{0}{0}\n", num);
        }

        static void Daysofweek()
        {
            Console.WriteLine("Enter the number(1-7): ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 1 && n <= 7)
            {
                daysinaweek day = (daysinaweek)(n-1);
                Console.WriteLine("The day is " + day);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        static void array1()
        {
            //int[] arr1 = { 56, 76, 98, 23, 94 };
            int[] arr1 = new int[5];
            Console.WriteLine("Enter number");

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine($"num{i + 1}:");
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            int total = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                total += arr1[i];
            }

            double avg = total / arr1.Length;
            Console.WriteLine($"The average of the array is {avg}");


            int min = arr1[0];
            int max = arr1[0];
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] > max)
                {
                    max = arr1[i];
                }
                if (arr1[i] < min)
                {
                    min = arr1[i];
                }

            }
            Console.WriteLine("Minimum Value" + min);
            Console.WriteLine("Maximum Value" + max);


        }
        static void tenmarks()
        {
            int[] score = new int[10];
            Console.WriteLine("Enter marks:");

            for (int i = 0; i < score.Length; i++)
            {
                Console.WriteLine($"Mark{i + 1}:");
                score[i] = Convert.ToInt32(Console.ReadLine());
            }
            int total = 0, min = score[0], max = score[0];
            foreach (int i in score)
            {
                total += i;
                if (i < min) min = i;
                if (i > max) max = i;
            }

            double average = total / 10;
            Console.WriteLine($"Average:{average}");
            Console.WriteLine($"Minimum:{min}");
            Console.WriteLine($"Maximum:{max}");
            Console.WriteLine($"Total:{total}");
            Array.Sort(score);
            Console.WriteLine("Ascending Order:");
            array(score);
            Console.WriteLine("Descending Order:");
            Array.Reverse(score);
            array(score);
        }

        static void arraycopy()
        {
            Console.WriteLine("Enter number of elements:");
            int n = int.Parse(Console.ReadLine());
            int[] original = new int[n];
            int[] copy = new int[n];
            Console.WriteLine("Enter elements of original array");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}:");
                original[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                copy[i] = original[i];
            }
            Console.WriteLine("Original Array:");
            array(original);
            Console.WriteLine("Copy Array");
            array(copy);
        }



        static void array(int[] array)
        {
            foreach (int num in array)
            {
                Console.WriteLine(num + " ");
            }
            Console.WriteLine();
        }



        static void Main(string[] args)
        {
            Console.WriteLine("------------------Swapping of Two numbers-------------------");
            swap();

            Console.WriteLine("-------------Numbers To be displayed in a row----------------");
            display();

            Console.WriteLine("------------------Days of a week in number-------------------");
            Daysofweek();

            Console.WriteLine("--------------Average,Minimum and Maximum Value--------------");
            array1();

            Console.WriteLine("---------------Marks-----------");
            tenmarks();

            Console.WriteLine("-----------------Copy Array------------");
            arraycopy();

            Console.ReadLine();

        }
    }
}
