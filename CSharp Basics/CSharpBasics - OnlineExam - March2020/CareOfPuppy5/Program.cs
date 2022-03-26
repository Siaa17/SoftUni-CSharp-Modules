using System;

namespace CareOfPuppy5
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodInKilos = int.Parse(Console.ReadLine());
            int foodInGrams = foodInKilos * 1000;
            int eatenFood = 0;
            string input = Console.ReadLine();

            while (input != "Adopted")
            {
                eatenFood = int.Parse(input);
                foodInGrams -= eatenFood;

                input = Console.ReadLine();
            }

            if (foodInGrams >= 0)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodInGrams} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(foodInGrams)} grams more.");
            }
        }
    }
}
