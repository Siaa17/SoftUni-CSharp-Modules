using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTimeInSec = int.Parse(Console.ReadLine());
            int secondTimeInSec = int.Parse(Console.ReadLine());
            int thirdTimeInSec = int.Parse(Console.ReadLine());

            int totalTime = firstTimeInSec + secondTimeInSec + thirdTimeInSec;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
