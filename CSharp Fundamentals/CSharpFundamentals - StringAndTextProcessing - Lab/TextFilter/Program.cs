using System;
using System.Linq;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            string text = Console.ReadLine();

            foreach (string bannedWord in bannedWords)
            {
                if (text.Contains(bannedWord))
                {
                    string replacement = new string('*', bannedWord.Length);

                    text = text.Replace(bannedWord, replacement);
                }
            }

            Console.WriteLine(text);
        }
    }
}
