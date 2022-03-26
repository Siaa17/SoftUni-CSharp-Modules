using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            int length = int.Parse(Console.ReadLine());

            Predicate<string> filter = name => name.Length <= length;

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(name => filter(name))
                .ToArray();

            print(names);

            /* int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> print = name =>
            {
                Predicate<string> filter = name => name.Length <= length;

                foreach (string currentName in names.Where(name => filter(name)))
                {
                    Console.WriteLine(currentName);
                }
            };

            print(names); */
        }
    }
}
