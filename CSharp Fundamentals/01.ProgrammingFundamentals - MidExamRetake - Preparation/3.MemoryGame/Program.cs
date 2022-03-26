using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> twinsElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int movesCount = 0;

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                movesCount++;

                string[] indices = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int index1 = int.Parse(indices[0]);
                int index2 = int.Parse(indices[1]);

                if (index1 == index2 ||
                    index1 < 0 || index2 < 0 ||
                    index1 >= twinsElements.Count ||
                    index2 >= twinsElements.Count)
                {
                    twinsElements.Insert(twinsElements.Count / 2, $"-{movesCount}a");
                    twinsElements.Insert(twinsElements.Count / 2, $"-{movesCount}a");

                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    continue;
                }
                else
                {
                    if (twinsElements[index1] == twinsElements[index2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {twinsElements[index1]}!");

                        string elementsToRemove = twinsElements[index1];

                        twinsElements.RemoveAll(n => n == elementsToRemove);

                        if (twinsElements.Count == 0)
                        {
                            Console.WriteLine($"You have won in {movesCount} turns!");

                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                } 
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", twinsElements));
        }
    }
}
