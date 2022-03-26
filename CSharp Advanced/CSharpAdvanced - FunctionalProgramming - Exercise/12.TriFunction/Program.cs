using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isEqualOrLargerFunc = (name, targetValue) => name.Sum(ch => ch) >= targetValue;

            Func<string[], int, Func<string, int, bool>, string> targetName = (collection, targetValue, func) =>
            collection.FirstOrDefault(name => func(name, targetValue));

            int targetSum = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine(targetName(inputNames, targetSum, isEqualOrLargerFunc));

            /* Func<string, int, bool> isEqualOrLargerFunc = (name, targetValue) => name.Sum(ch => ch) >= targetValue;

            int targetSum = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string[], Func<string, int, bool>, string> targetName = (collection, func) =>
            collection.FirstOrDefault(name => func(name, targetSum));

            Console.WriteLine(targetName(inputNames, isEqualOrLargerFunc)); */
        }
    }
}
