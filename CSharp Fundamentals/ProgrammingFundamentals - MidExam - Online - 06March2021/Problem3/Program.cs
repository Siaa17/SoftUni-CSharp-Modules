using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = Console.ReadLine()
                .Split('&', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string line = String.Empty;

            while ((line = Console.ReadLine()) != "Done")
            {
                string[] elements = line
                    .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];

                if (command == "Add Book")
                {
                    string bookName = elements[1];

                    if (!shelf.Contains(bookName))
                    {
                        shelf.Insert(0, bookName);
                    }
                }
                else if (command == "Take Book")
                {
                    string bookName = elements[1];

                    if (shelf.Contains(bookName))
                    {
                        shelf.Remove(bookName);
                    }
                }
                else if (command == "Swap Books")
                {
                    string book1 = elements[1];
                    string book2 = elements[2];

                    if (shelf.Contains(book1) && shelf.Contains(book2))
                    {
                        int indexOfBook1 = shelf.IndexOf(book1);
                        int indexOfBook2 = shelf.IndexOf(book2);

                        shelf.Insert(indexOfBook1, book2);
                        shelf.RemoveAt(indexOfBook1 + 1);
                        shelf.Insert(indexOfBook2, book1);
                        shelf.RemoveAt(indexOfBook2 + 1);
                    }
                }
                else if (command == "Insert Book")
                {
                    string bookName = elements[1];

                    shelf.Add(bookName);
                }
                else if (command == "Check Book")
                {
                    int index = int.Parse(elements[1]);

                    if (index >= 0 && index < shelf.Count)
                    {
                        string currentBook = shelf[index];

                        Console.WriteLine(currentBook);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", shelf));
        }
    }
}
