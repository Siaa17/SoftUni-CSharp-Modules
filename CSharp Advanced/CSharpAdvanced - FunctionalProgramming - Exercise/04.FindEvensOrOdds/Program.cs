using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            int[] numBounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startNumber = numBounds[0];
            int endNumber = numBounds[1];

            string command = Console.ReadLine();

            Predicate<int> predicate = command == "odd"
                ? new Predicate<int>(n => n % 2 != 0)
                : new Predicate<int>(n => n % 2 == 0);

            List<int> result = new List<int>();

            for (int num = startNumber; num <= endNumber; num++)
            {
                if (predicate(num))
                {
                    result.Add(num);
                }
            }

            print(result);
        }
    }
}
