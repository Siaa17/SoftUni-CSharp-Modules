using System;

namespace ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal distanceInMeters = decimal.Parse(Console.ReadLine());

            decimal distanceInKilometers = distanceInMeters / 1000;

            Console.WriteLine($"{distanceInKilometers:F2}");
        }
    }
}
