using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            double avgNum = numbers.Sum() / numbers.Count; //numbers.Average();

            List<double> topNums = new List<double>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > avgNum)
                {
                    topNums.Add(numbers[i]);
                }
            }

            topNums = topNums.OrderByDescending(n => n).ToList();

            if (topNums.Count > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{topNums[i]} ");
                }

                Console.WriteLine();
            }
            else if (topNums.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", topNums));
            }
        }
    }
}
