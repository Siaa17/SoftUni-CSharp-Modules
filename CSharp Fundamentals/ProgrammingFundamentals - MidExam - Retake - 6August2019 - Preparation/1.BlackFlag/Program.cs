using System;

namespace _1.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5;
                }

                if (i % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.3;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:F2} plunder gained.");
            }
            else
            {
                double plunderInPercentage = (totalPlunder / expectedPlunder) * 100;

                Console.WriteLine($"Collected only {plunderInPercentage:F2}% of the plunder.");
            }
        }
    }
}
