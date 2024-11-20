using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment3
{
    public class CricketTeam
    {
        public void PointsCalc(int match)
        {
            int sum = 0;
            int score;

            for (int i = 1; i <= match; i++)
            {
                Console.Write($"Enter the points scored by the team in match {i}: ");
                score = Convert.ToInt32(Console.ReadLine());
                sum += score;
            }

            double average = (double)sum / match;

            Console.WriteLine($"\nTotal matches played: {match}");
            Console.WriteLine($"Points scored: {sum}");
            Console.WriteLine($"Avg points: {average:F3}");
        }
    }

    class Ipl
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter the number of matches played: ");
            int matches = Convert.ToInt32(Console.ReadLine());
            team.PointsCalc(matches);
            Console.Read();
        }
    }
}
