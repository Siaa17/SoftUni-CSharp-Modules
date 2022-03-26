using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> sortedNums = new SortedDictionary<double, int>();

            foreach (double number in numbers)
            {
                if (sortedNums.ContainsKey(number))
                {
                    sortedNums[number]++;
                }
                else
                {
                    sortedNums.Add(number, 1);
                }
            }

            foreach (KeyValuePair<double, int> nums in sortedNums)
            {
                Console.WriteLine($"{nums.Key} -> {nums.Value}");
            }
        }
    }
}
