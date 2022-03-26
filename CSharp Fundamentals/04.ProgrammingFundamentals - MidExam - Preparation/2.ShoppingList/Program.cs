using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string line = String.Empty;

            while ((line = Console.ReadLine()) != "Go Shopping!")
            {
                string[] lineParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = lineParts[0];
                string item = lineParts[1];

                if (command == "Urgent")
                {
                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0, item);
                    }
                }
                else if (command == "Unnecessary")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }
                else if (command == "Correct")
                {
                    string secondItem = lineParts[2];

                    if (groceries.Contains(item))
                    {
                        int indexOfOldItem = groceries.IndexOf(item);

                        groceries.RemoveAt(indexOfOldItem);
                        groceries.Insert(indexOfOldItem, secondItem);      
                    }
                }
                else if (command == "Rearrange")
                {
                    if (groceries.Contains(item))
                    {
                        int currentIndex = groceries.IndexOf(item);

                        groceries.RemoveAt(currentIndex);
                        groceries.Add(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
