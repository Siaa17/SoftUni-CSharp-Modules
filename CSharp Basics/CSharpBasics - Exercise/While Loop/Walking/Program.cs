using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 10000;

            int stepsCount = 0;
            int currentSteps = 0;

            while (stepsCount < target)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    currentSteps = int.Parse(Console.ReadLine());
                    stepsCount += currentSteps;
                    break;
                }
                else
                {
                    currentSteps = int.Parse(input);
                    stepsCount += currentSteps;
                }
            }

            if (stepsCount >= target)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsCount - target} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{target - stepsCount} more steps to reach goal.");
            }
        }
    }
}
