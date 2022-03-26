using System;

namespace Santa_sDeers2
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfAbsence = int.Parse(Console.ReadLine());
            int leftFoodInKilos = int.Parse(Console.ReadLine());
            double foodPerDay1stDeer = double.Parse(Console.ReadLine());
            double foodPerDay2ndDeer = double.Parse(Console.ReadLine());
            double foodPerDay3thDeer = double.Parse(Console.ReadLine());

            foodPerDay1stDeer *= daysOfAbsence;
            foodPerDay2ndDeer *= daysOfAbsence;
            foodPerDay3thDeer *= daysOfAbsence;

            double totalNeededFood = foodPerDay1stDeer + foodPerDay2ndDeer + foodPerDay3thDeer;

            if (leftFoodInKilos >= totalNeededFood)
            {
                Console.WriteLine($"{Math.Floor(leftFoodInKilos - totalNeededFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalNeededFood - leftFoodInKilos)} more kilos of food are needed.");
            }
        }
    }
}
