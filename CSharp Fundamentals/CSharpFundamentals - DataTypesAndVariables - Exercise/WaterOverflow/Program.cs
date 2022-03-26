using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int capacity = 255;
            int totalLitersInTank = 0;
            
            for (int i = 1; i <= n; i++)
            {
                int waterToPour = int.Parse(Console.ReadLine());

                bool isCapacitySufficient = totalLitersInTank + waterToPour <= capacity;

                if (isCapacitySufficient)
                {
                    totalLitersInTank += waterToPour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(totalLitersInTank);
        }
    }
}
