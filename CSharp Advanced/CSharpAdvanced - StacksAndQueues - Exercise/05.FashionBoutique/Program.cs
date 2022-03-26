using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxOfClothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(boxOfClothes);

            int rackCounter = 1;
            int sum = 0;

            while (stack.Count > 0)
            {
                int currentClothes = stack.Peek();

                sum += currentClothes;

                if (sum > rackCapacity)
                {
                    rackCounter++;
                    sum = 0;
                }
                else
                {
                    stack.Pop();
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
