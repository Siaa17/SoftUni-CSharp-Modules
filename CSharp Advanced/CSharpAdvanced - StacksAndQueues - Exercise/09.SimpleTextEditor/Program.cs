using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            Stack<string> text = new Stack<string>();

            text.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] commandData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandData[0];

                switch (command)
                {
                    case "1":
                        string charsToAppend = commandData[1];

                        sb.Append(charsToAppend);
                        text.Push(sb.ToString());
                        break;
                    case "2":
                        int charsToErase = int.Parse(commandData[1]);

                        sb.Remove(sb.Length - charsToErase, charsToErase);
                        text.Push(sb.ToString());
                        break;
                    case "3":
                        int charIndex = int.Parse(commandData[1]);

                        Console.WriteLine(sb[charIndex - 1]);
                        break;
                    case "4":
                        text.Pop();
                        sb.Clear();
                        sb.Append(text.Peek());
                        break;
                }
            }
        }
    }
}
