using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> customComparator = (num1, num2) =>
            (num1 % 2 == 0 && num2 % 2 != 0) ? -1 :
            (num1 % 2 != 0 && num2 % 2 == 0) ? 1 :
            num1.CompareTo(num2);

            Array.Sort<int>(numbers, new Comparison<int>(customComparator));

            Console.WriteLine(string.Join(" ", numbers));

            /* Array.Sort(numbers, (num1, num2) =>
            num1 % 2 == 0 && num2 % 2 != 0 ? -1 :
            num1 % 2 != 0 && num2 % 2 == 0 ? 1 :
            num1.CompareTo(num2));

            Console.WriteLine(string.Join(" ", numbers)); */
        }
    }
}
