using System;

namespace MovieDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int photosTime = int.Parse(Console.ReadLine());
            int scenesCount = int.Parse(Console.ReadLine());
            int sceneDuration = int.Parse(Console.ReadLine());

            double locationPrep = photosTime * 0.15;
            int totalTimeForShooting = scenesCount * sceneDuration;
            double totalNecessaryTime = locationPrep + totalTimeForShooting;

            double timeDiff = Math.Abs(photosTime - totalNecessaryTime);
            double roundedTimeDiff = Math.Round(timeDiff);

            if (totalNecessaryTime <= photosTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {roundedTimeDiff} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {roundedTimeDiff} minutes.");
            }
        }
    }
}
