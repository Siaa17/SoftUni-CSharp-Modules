using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> elements = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "1")
                {
                    int elToPush = int.Parse(cmdArgs[1]);

                    elements.Push(elToPush);
                }
                else if (cmdType == "2")
                {
                    if (elements.Count > 0)
                    {
                        elements.Pop();
                    }
                }
                else if (cmdType == "3")
                {
                    if (elements.Count > 0)
                    {
                        Console.WriteLine(elements.Max());
                    }
                }
                else if (cmdType == "4")
                {
                    if (elements.Count > 0)
                    {
                        Console.WriteLine(elements.Min());
                    }
                }
            }

            Console.WriteLine(String.Join(", ", elements));
        }
    }
}
