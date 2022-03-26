using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split('|')
                .Reverse()
                .ToList();

            List<string> result = new List<string>();

            foreach (string element in elements)
            {
                string[] numbers = element
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                result.AddRange(numbers);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
