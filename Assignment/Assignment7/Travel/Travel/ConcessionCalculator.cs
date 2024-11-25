using System;

namespace TravelConcessionLibrary
{
    public class ConcessionCalculator
    {
        int TotalFare = 500;

        public void CalculateConcession(string name, int age)
        {
            if (age <= 5)
            {
                Console.WriteLine($"{name}, Little Champs - Free Ticket");
            }
            else if (age > 60)
            {
                double concessionFare = TotalFare * 0.7;
                Console.WriteLine($"{name}, Senior Citizen - Concession Fare: {concessionFare}");
            }
            else
            {
                Console.WriteLine($"{name}, Ticket Booked - Fare: {TotalFare}");
            }
        }
    }
}
