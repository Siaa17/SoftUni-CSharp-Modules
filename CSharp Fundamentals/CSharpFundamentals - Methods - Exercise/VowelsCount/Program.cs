using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            PrintCountOfVowels(text);
        }

        static void PrintCountOfVowels(string text)
        {
            int vowelsCounter = 0;

            foreach (char letter in text)
            {
                if (letter == 'a' ||
                    letter == 'e' ||
                    letter == 'o' ||
                    letter == 'i' ||
                    letter == 'u' ||
                    letter == 'y')
                {
                    vowelsCounter++;
                }
            }

            Console.WriteLine(vowelsCounter);
        }
    }
}
