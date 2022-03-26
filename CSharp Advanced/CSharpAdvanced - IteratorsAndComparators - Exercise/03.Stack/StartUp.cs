using System;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input
                    .Split(new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArgs[0];

                if (command == "Push")
                {
                    foreach (string element in commandArgs.Skip(1))
                    {
                        stack.Push(int.Parse(element));
                    }
                }
                else if (command == "Pop")
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
