using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> filter = num => num % divider != 0;

            numbers = numbers.Reverse().Where(filter).ToArray();

            print(numbers);
        }
    }
}
