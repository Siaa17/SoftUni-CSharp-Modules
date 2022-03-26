using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command.Length == 2)
                {
                    int wagon = int.Parse(command[1]);
                    train.Add(wagon);
                }
                else
                {
                    int passengers = int.Parse(command[0]);

                    for (int i = 0; i < train.Count; i++)
                    {
                        int currentWagon = train[i];

                        if (currentWagon + passengers <= maxCapacity)
                        {
                            train[i] += passengers;
                            break;   
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
