using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] elements = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string command = elements[0];
                string item = elements[1];

                if (command == "Collect")
                {
                    if (!journal.Contains(item))
                    {
                        journal.Add(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "Drop")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                    }
                }
                else if (command == "Combine Items")
                {
                    string[] items = item
                        .Split(':')
                        .ToArray();

                    string oldItem = items[0];
                    string newItem = items[1];

                    if (journal.Contains(oldItem))
                    {
                        int indexOfOldItem = journal.IndexOf(oldItem);

                        journal.Insert(indexOfOldItem + 1, newItem);
                    }
                }
                else if (command == "Renew")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                        journal.Add(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
