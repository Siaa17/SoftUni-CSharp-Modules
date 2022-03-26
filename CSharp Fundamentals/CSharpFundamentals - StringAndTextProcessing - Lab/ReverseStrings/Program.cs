using System;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;

            while ((word = Console.ReadLine()) != "end")
            {
                string reversedWord = string.Concat(word.Reverse());

                Console.WriteLine($"{word} = {reversedWord}");
            }
        }
    }
}
