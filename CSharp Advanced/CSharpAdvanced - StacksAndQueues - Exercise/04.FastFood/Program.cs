using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                int currFoodOrder = queue.Peek();

                if (quantityOfFood >= currFoodOrder)
                {
                    queue.Dequeue();

                    quantityOfFood -= currFoodOrder;
                }
                else
                {
                    Console.WriteLine($"Orders left: {String.Join(" ", queue)}");

                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
