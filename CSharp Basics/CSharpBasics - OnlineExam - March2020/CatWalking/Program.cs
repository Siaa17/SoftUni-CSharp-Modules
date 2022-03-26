using System;

namespace CatWalking2
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesWalkingPerDay = int.Parse(Console.ReadLine());
            int walkingsPerDay = int.Parse(Console.ReadLine());
            double caloriesPerDay = double.Parse(Console.ReadLine());

            int totalMinsWalkingPerDay = walkingsPerDay * minutesWalkingPerDay;
            int totalCalories = totalMinsWalkingPerDay * 5;
            caloriesPerDay *= 0.5;

            if (totalCalories >= caloriesPerDay)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalCalories}.");
            }
        }
    }
}
