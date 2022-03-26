using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = w => char.IsUpper(w[0]);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => predicate(w))
                .ToList()
                .ForEach(w => Console.WriteLine(w));

            /* Func<string, bool> predicate = w => char.IsUpper(w[0]);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(predicate)
                .ToList()
                .ForEach(w => Console.WriteLine(w)); */
        }
    }
}
