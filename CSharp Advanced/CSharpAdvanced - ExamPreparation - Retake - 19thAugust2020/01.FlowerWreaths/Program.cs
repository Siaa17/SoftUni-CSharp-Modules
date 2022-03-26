using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] roses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfLilies = new Stack<int>(lilies);
            Queue<int> queueOfRoses = new Queue<int>(roses);

            int sum = 0;
            int wreathsCounter = 0;
            int storedFlowers = 0;

            while (stackOfLilies.Count > 0 && queueOfRoses.Count > 0)
            {
                int lily = stackOfLilies.Pop();
                int rose = queueOfRoses.Dequeue();

                while (true)
                {
                    sum = lily + rose;

                    if (sum == 15)
                    {
                        wreathsCounter++;
                        break;
                    }
                    else if (sum > 15)
                    {
                        lily -= 2;
                    }
                    else if (sum < 15)
                    {
                        storedFlowers += sum;
                        break;
                    }
                }
            }

            wreathsCounter += storedFlowers / 15;

            if (wreathsCounter >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCounter} wreaths!");
            }
            else
            {
                int wreathsNeeded = 5 - wreathsCounter;

                Console.WriteLine($"You didn't make it, you need {wreathsNeeded} wreaths more!");
            }
        }
    }
}
