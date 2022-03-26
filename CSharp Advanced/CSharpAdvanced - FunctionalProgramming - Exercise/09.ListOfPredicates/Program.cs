using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> filter = (num, d) => num % d == 0;

            for (int num = 1; num <= endOfRange; num++)
            {
                if (dividers.All(d => filter(num, d)))
                {
                    Console.Write(num + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
