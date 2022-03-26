using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([#@])(?<wordOne>[A-Za-z]{3,})(\1)(\1)(?<wordTwo>[A-Za-z]{3,})(\1)";

            Regex regex = new Regex(pattern);

            MatchCollection matchedWords = regex.Matches(text);

            List<string> mirrorWords = new List<string>();

            if (matchedWords.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchedWords.Count} word pairs found!");
            }

            foreach (Match match in matchedWords)
            {
                string firstWord = match.Groups["wordOne"].Value;
                string secondWord = match.Groups["wordTwo"].Value;

                string firstWordReversed = new string(firstWord.Reverse().ToArray());
                string secondWordReversed = new string(secondWord.Reverse().ToArray());

                if (firstWord == secondWordReversed)
                {
                    mirrorWords.Add(firstWord + " <=> " + firstWordReversed);
                }
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
