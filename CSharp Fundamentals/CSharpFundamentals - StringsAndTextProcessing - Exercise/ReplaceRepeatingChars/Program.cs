using System;
using System.Text;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            char previousLetter = '\0';

            StringBuilder result = new StringBuilder();

            foreach (char letter in word)
            {
                if (letter != previousLetter)
                {
                    result.Append(letter);
                }

                previousLetter = letter;
            }

            Console.WriteLine(result);
        }
    }
}
