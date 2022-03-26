using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            while (text.Contains(wordToRemove))
            {
                int indexToRemove = text.IndexOf(wordToRemove);
                text = text.Remove(indexToRemove, wordToRemove.Length);
            }

            Console.WriteLine(text);
        }
    }
}
