using System;

namespace FoodForPets4
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalFoodAmount = double.Parse(Console.ReadLine());

            double biscuits = 0;
            double sumEatenFood = 0;
            double totalEatenDogFood = 0;
            double totalEatenCatFood = 0;

            for (int i = 1; i <= days; i++)
            {
                double eatenDogFood = int.Parse(Console.ReadLine());
                double eatenCatFood = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    double currentBiscuits = 0.10 * (eatenDogFood + eatenCatFood);
                    biscuits += currentBiscuits; 
                }

                sumEatenFood += eatenDogFood + eatenCatFood;
                totalEatenDogFood += eatenDogFood;
                totalEatenCatFood += eatenCatFood;
            }

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{(sumEatenFood / totalFoodAmount) * 100:F2}% of the food has been eaten.");
            Console.WriteLine($"{(totalEatenDogFood / sumEatenFood) * 100:F2}% eaten from the dog.");
            Console.WriteLine($"{(totalEatenCatFood / sumEatenFood) * 100:F2}% eaten from the cat.");
        }
    }
}
