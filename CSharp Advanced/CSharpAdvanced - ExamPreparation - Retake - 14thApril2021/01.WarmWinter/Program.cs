using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();

            int[] hats = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] scarfs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfHats = new Stack<int>(hats);
            Queue<int> QueueOfScarfs = new Queue<int>(scarfs);

            while (stackOfHats.Count > 0 && QueueOfScarfs.Count > 0)
            {
                if (stackOfHats.Peek() > QueueOfScarfs.Peek())
                {
                    sets.Add(stackOfHats.Peek() + QueueOfScarfs.Peek());
                    stackOfHats.Pop();
                    QueueOfScarfs.Dequeue();
                }
                else if (QueueOfScarfs.Peek() > stackOfHats.Peek())
                {
                    stackOfHats.Pop();
                }
                else if (stackOfHats.Peek().Equals(QueueOfScarfs.Peek()))
                {
                    QueueOfScarfs.Dequeue();
                    stackOfHats.Push(stackOfHats.Pop() + 1);
                }
            }

            int maxPriceSet = sets.Max();

            Console.WriteLine($"The most expensive set is: {maxPriceSet}");

            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
