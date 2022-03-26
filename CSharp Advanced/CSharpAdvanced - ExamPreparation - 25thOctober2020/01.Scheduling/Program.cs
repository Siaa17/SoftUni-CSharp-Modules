using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threads = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToBeKilled = int.Parse(Console.ReadLine());

            Stack<int> stackOfTasks = new Stack<int>(tasks);
            Queue<int> queueOfThreads = new Queue<int>(threads);

            while (stackOfTasks.Peek() != taskToBeKilled)
            {
                if (queueOfThreads.Peek() >= stackOfTasks.Peek())
                {
                    stackOfTasks.Pop();
                    queueOfThreads.Dequeue();
                }
                else
                {
                    queueOfThreads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {queueOfThreads.Peek()} killed task {taskToBeKilled}");

            Console.WriteLine(string.Join(" ", queueOfThreads));
        }
    }
}
