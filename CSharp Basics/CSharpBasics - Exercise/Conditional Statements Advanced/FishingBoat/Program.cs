using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int countFishers = int.Parse(Console.ReadLine());

            double rent = 0;

            switch (season)
            {
                case "Spring":
                    rent = 3000;
                    break;
                    case "Summer":
                case "Autumn":
                    rent = 4200;
                    break;
                case "Winter":
                    rent = 2600;
                    break;
            }

           
            if (countFishers <= 6)
            {
                rent -= 0.10 * rent;
            }
            else if (countFishers >= 7 && countFishers <= 11)
            {
                rent -= 0.15 * rent;
            }
            else if (countFishers >= 12)
            {
                rent -= 0.25 * rent;
            }

            if (countFishers % 2 == 0 && season != "Autumn")
            {
                rent -= 0.05 * rent; 
            }

            if (budget >= rent)
            {
                Console.WriteLine($"Yes! You have {budget - rent:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rent - budget:F2} leva.");
            }
        }
    }
}
