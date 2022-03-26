using System;
using System.Linq;

namespace _3._1.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double avgNum = numbers.Average();

            int[] result = numbers
                .Where(n => n > avgNum)
                .OrderByDescending(n => n)
                .Take(5)
                .ToArray();

            if (result.Length == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
