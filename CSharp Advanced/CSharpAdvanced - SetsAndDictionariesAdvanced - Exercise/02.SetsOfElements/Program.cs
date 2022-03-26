using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            FillSets(firstSet, lengths[0]);
            FillSets(secondSet, lengths[1]);

            CheckSets(firstSet, secondSet);
        }

        static void CheckSets(HashSet<int> firstSet, HashSet<int> secondSet)
        {
            //HashSet<int> repeatedNums = new HashSet<int>();
            List<int> repeatedNums = new List<int>();

            foreach (int number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    repeatedNums.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", repeatedNums));
        }

        static HashSet<int> FillSets(HashSet<int> set, int length)
        {
            for (int i = 0; i < length; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }

            return set;
        }
    }
}
