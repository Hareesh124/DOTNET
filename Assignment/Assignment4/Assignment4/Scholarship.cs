using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            double scholarshipAmount = 0.0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = 0.20 * fees;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = 0.30 * fees;
            }
            else if (marks > 90)
            {
                scholarshipAmount = 0.50 * fees;
            }

            return scholarshipAmount;
        }

        public static void Main(string[] args)
        {
            Scholarship scholarship = new Scholarship();
            double scholarshipAmount = scholarship.Merit(75, 10000);
            Console.WriteLine("Scholarship Amount: " + scholarshipAmount);
            Console.Read();
        }
    }
}
