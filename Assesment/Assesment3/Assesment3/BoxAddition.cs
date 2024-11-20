using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment3
{
    public class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }

        public Box(int length, int breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box AddBoxes(Box box1, Box box2)
        {
            int newLength = box1.Length + box2.Length;
            int newBreadth = box1.Breadth + box2.Breadth;
            return new Box(newLength, newBreadth);
        }

        public void DisplayBoxDetails()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }
    class BoxAddition
    {
        static void Main(string[] args)
        {
            int l1, l2, b1, b2;
            Console.WriteLine("Enter the length 1 : ");
            l1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the length 2 : ");
            l2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth 1 : ");
            b1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth 2 : ");
            b2 = Convert.ToInt32(Console.ReadLine());
            Box box1 = new Box(l1, b1);
            Box box2 = new Box(l2, b2);

            Box resultBox = Box.AddBoxes(box1, box2);

            Console.WriteLine("Details of the new box after addition:");
            resultBox.DisplayBoxDetails();
            Console.Read();
        }
    }
}
