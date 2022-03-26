using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];
                int index = int.Parse(elements[1]);
                int value = int.Parse(elements[2]);

                if (index < 0 || index >= targets.Count)
                {
                    if (command == "Add")
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else if (command == "Strike")
                    {
                        Console.WriteLine($"Strike missed!");
                    }

                    continue;
                }

                if (command == "Shoot")
                {
                    targets[index] -= value;

                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (command == "Add")
                {
                    targets.Insert(index, value);
                }
                else if (command == "Strike")
                {
                    if (index - value < 0 || index + value >= targets.Count)
                    {
                        Console.WriteLine($"Strike missed!");

                        continue;
                    }

                    for (int i = index - value; i <= index + value; i++)
                    {
                        targets.RemoveAt(index - value);
                    }
                }
            }

            Console.WriteLine(string.Join('|', targets)); 
        }
    }
}
