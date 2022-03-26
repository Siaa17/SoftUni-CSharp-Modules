using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueChemElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicalElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (string element in chemicalElements)
                {
                    uniqueChemElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueChemElements));
        }
    }
}
