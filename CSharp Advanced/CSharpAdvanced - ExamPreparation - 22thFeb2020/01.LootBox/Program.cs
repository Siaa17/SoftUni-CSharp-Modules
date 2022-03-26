using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> claimedItems = new List<int>();

            Queue<int> queueOfFirstBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> stackOfSecondBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            while (queueOfFirstBox.Count > 0 && stackOfSecondBox.Count > 0)
            {
                int firstBox = queueOfFirstBox.Peek();
                int secondBox = stackOfSecondBox.Peek();

                int sum = firstBox + secondBox;

                while (true)
                {
                    if (sum % 2 == 0)
                    {
                        claimedItems.Add(sum);
                        queueOfFirstBox.Dequeue();
                        stackOfSecondBox.Pop();
                        break;
                    }
                    else
                    {
                        queueOfFirstBox.Enqueue(stackOfSecondBox.Pop());
                        break;
                    }
                }
            }

            if (queueOfFirstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (stackOfSecondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int claimedItemsSum = claimedItems.Sum();

            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }
        }
    }
}
