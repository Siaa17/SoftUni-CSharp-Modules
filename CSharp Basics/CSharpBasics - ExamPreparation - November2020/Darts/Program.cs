using System;

namespace Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int score = 301;
            int successfulShots = 0;
            int unsuccessfulShots = 0;
            bool isPlayerWin = false;

            string area = Console.ReadLine();

            while (area != "Retire")
            {
                int initialPoints = int.Parse(Console.ReadLine());
                int currentPoints = 0;

                switch (area)
                {
                    case "Single":
                        currentPoints = initialPoints;
                        break;
                    case "Double":
                        currentPoints = initialPoints * 2;
                        break;
                    case "Triple":
                        currentPoints = initialPoints * 3;
                        break;
                }

                if (score - currentPoints >= 0)
                {
                    successfulShots++;
                    score -= currentPoints;
                    
                }
                else
                {
                    unsuccessfulShots++;
                }

                if (score == 0)
                {
                    isPlayerWin = true;
                    break;
                }

                area = Console.ReadLine();
            }

            if (isPlayerWin)
            {
                Console.WriteLine($"{name} won the leg with {successfulShots} shots.");
            }
            else
            {
                Console.WriteLine($"{name} retired after {unsuccessfulShots} unsuccessful shots.");
            }
        }
    }
}
