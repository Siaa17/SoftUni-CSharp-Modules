using System;
using System.Linq;

namespace _2.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int count = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index < 0 || index >= targets.Length || targets[index] == -1)
                {
                    input = Console.ReadLine();

                    continue;
                }

                int shotTargetValue = targets[index];
                targets[index] = -1;
                count++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] != -1)
                    {
                        if (targets[i] > shotTargetValue)
                        {
                            targets[i] -= shotTargetValue;
                        }
                        else
                        {
                            targets[i] += shotTargetValue;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", targets)}");
        }
    }
}
