using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        { 
            double recordInSec = double.Parse(Console.ReadLine());
            double distanceInM = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double totalSeconds = distanceInM * secondsPerMeter;

            totalSeconds += Math.Floor(distanceInM / 15) * 12.5;

            if (totalSeconds < recordInSec)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {totalSeconds:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalSeconds - recordInSec:F2} seconds slower.");
            }
        }
    }
}
