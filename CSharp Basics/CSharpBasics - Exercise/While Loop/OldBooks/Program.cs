using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            string currentBook = Console.ReadLine();

            int count = 0;
            while (currentBook != "No More Books")
            {
                if (currentBook == wantedBook)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
                count++;
                currentBook = Console.ReadLine();
            }

            if (wantedBook != currentBook)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}
