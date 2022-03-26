using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double expenses = 0;
            string destination = "";
            string accommodation = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    accommodation = "Camp";
                    expenses = 0.30 * budget;
                }
                else if (season == "winter")
                {
                    accommodation = "Hotel";
                    expenses = 0.70 * budget;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    accommodation = "Camp";
                    expenses = 0.40 * budget;
                }
                else if (season == "winter")
                {
                    accommodation = "Hotel";
                    expenses = 0.80 * budget;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                accommodation = "Hotel";
                expenses = 0.90 * budget;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accommodation} - {expenses:F2}");
        }
    }
}
