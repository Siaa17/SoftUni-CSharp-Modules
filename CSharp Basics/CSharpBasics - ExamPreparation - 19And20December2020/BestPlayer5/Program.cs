using System;

namespace BestPlayer5
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            
            int maxGoals = int.MinValue;
            string bestPlayer = "";

            while (playerName != "END")
            {
                int goalsScoredCount = int.Parse(Console.ReadLine());

                if (goalsScoredCount > maxGoals)
                {
                    maxGoals = goalsScoredCount;
                    bestPlayer = playerName;
                }

                if (maxGoals >= 10)
                {
                    break;
                }

                playerName = Console.ReadLine();    
            }

            Console.WriteLine($"{bestPlayer} is the best player!");

            if (maxGoals >= 3)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}