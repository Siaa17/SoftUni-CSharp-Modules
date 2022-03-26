using System;

namespace HairSalon5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyTarget = int.Parse(Console.ReadLine());

            int earnings = 0;
            bool isTargetReached = false;

            string command = Console.ReadLine();

            while (command != "closed")
            {
                if (command == "haircut")
                {
                    command = Console.ReadLine();

                    if (command == "mens")
                    {
                        earnings += 15;
                    }
                    else if (command == "ladies")
                    {
                        earnings += 20;
                    }
                    else if (command == "kids")
                    {
                        earnings += 10;
                    }
                }
                else if (command == "color")
                {
                    command = Console.ReadLine();

                    if (command == "touch up")
                    {
                        earnings += 20;
                    }
                    else if (command == "full color")
                    {
                        earnings += 30;
                    }
                }

                if (earnings >= dailyTarget)
                {
                    isTargetReached = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isTargetReached)
            {
                Console.WriteLine("You have reached your target for the day!");
            }
            else 
            {
                Console.WriteLine($"Target not reached! You need {dailyTarget - earnings}lv. more.");
            }

            Console.WriteLine($"Earned money: {earnings}lv.");
        }
    }
}
