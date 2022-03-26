using System;

namespace GrandpaStavri4
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());

            double totalLiters = 0;
            double totalDegrees = 0;

            for (int day = 1; day <= daysCount; day++)
            {
                double rakiaInLiters = double.Parse(Console.ReadLine());
                totalLiters += rakiaInLiters;

                double rakiaDegrees = double.Parse(Console.ReadLine());
                totalDegrees += rakiaInLiters * rakiaDegrees;
            }

            double averageDegrees = totalDegrees / totalLiters;

            Console.WriteLine($"Liter: {totalLiters:F2}");
            Console.WriteLine($"Degrees: {averageDegrees:F2}");

            if (averageDegrees < 38)
            {
                Console.WriteLine($"Not good, you should baking!");
            }
            else if (averageDegrees >= 38 && averageDegrees <= 42)
            {
                Console.WriteLine($"Super!");
            }
            else if (averageDegrees > 42)
            {
                Console.WriteLine($"Dilution with distilled water!");
            }
        }
    }
}
