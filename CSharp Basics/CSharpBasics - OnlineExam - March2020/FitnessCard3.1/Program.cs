using System;

namespace FitnessCard3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double extantMoney = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double fitnessCardPrice = 0;

            switch (gender)
            {
                case 'm':
                    switch (sport)
                    {
                        case "Gym":
                            fitnessCardPrice = 42;
                            break;
                        case "Boxing":
                            fitnessCardPrice = 41;
                            break;
                        case "Yoga":
                            fitnessCardPrice = 45;
                            break;
                        case "Zumba":
                            fitnessCardPrice = 34;
                            break;
                        case "Dances":
                            fitnessCardPrice = 51;
                            break;
                        case "Pilates":
                            fitnessCardPrice = 39;
                            break;
                    }
                    break;
                case 'f':
                    switch (sport)
                    {
                        case "Gym":
                            fitnessCardPrice = 35;
                            break;
                        case "Boxing":
                            fitnessCardPrice = 37;
                            break;
                        case "Yoga":
                            fitnessCardPrice = 42;
                            break;
                        case "Zumba":
                            fitnessCardPrice = 31;
                            break;
                        case "Dances":
                            fitnessCardPrice = 53;
                            break;
                        case "Pilates":
                            fitnessCardPrice = 37;
                            break;
                    }
                    break;
            }

            if (age <= 19)
            {
                fitnessCardPrice *= 0.80;
            }

            if (extantMoney >= fitnessCardPrice)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${Math.Abs(extantMoney - fitnessCardPrice):F2} more.");
            }
        }
    }
}
