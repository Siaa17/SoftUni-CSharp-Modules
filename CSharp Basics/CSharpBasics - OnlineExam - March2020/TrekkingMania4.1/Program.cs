using System;

namespace TrekkingMania4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsOfClimbersCount = int.Parse(Console.ReadLine());

            double musala = 0;
            double montBlanc = 0;
            double kilimanjaro = 0;
            double k2 = 0;
            double everest = 0;

            int totalClimbers = 0;

            for (int group = 1; group <= groupsOfClimbersCount; group++)
            {
                int climbersPerGroup = int.Parse(Console.ReadLine());

                if (climbersPerGroup <= 5)
                {
                    musala += climbersPerGroup;
                }
                else if (climbersPerGroup >= 6 && climbersPerGroup <= 12)
                {
                    montBlanc += climbersPerGroup;
                }
                else if (climbersPerGroup >= 13 && climbersPerGroup <= 25)
                {
                    kilimanjaro += climbersPerGroup;
                }
                else if (climbersPerGroup >= 26 && climbersPerGroup <= 40)
                {
                    k2 += climbersPerGroup;
                }
                else if (climbersPerGroup >= 41)
                {
                    everest += climbersPerGroup;
                }

                totalClimbers += climbersPerGroup;
            }

            double climbingMusalaPercent = musala / totalClimbers * 100;
            double climbingMontBlancPercent = montBlanc / totalClimbers * 100;
            double climbingKilimanjaroPercent = kilimanjaro / totalClimbers * 100;
            double climbingK2Percent = k2 / totalClimbers * 100;
            double climbingEverestPercent = everest / totalClimbers * 100;

            Console.WriteLine($"{climbingMusalaPercent:F2}%");
            Console.WriteLine($"{climbingMontBlancPercent:F2}%");
            Console.WriteLine($"{climbingKilimanjaroPercent:F2}%");
            Console.WriteLine($"{climbingK2Percent:F2}%");
            Console.WriteLine($"{climbingEverestPercent:F2}%");
        }
    }
}
