using System;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            
            string digitsPattern = @"\d";
           
            MatchCollection matchedDigits = Regex.Matches(text, digitsPattern);

            long coolThresholdSum = 1;

            foreach (Match digit in matchedDigits)
            {
                coolThresholdSum *= int.Parse(digit.ToString());
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            string emojisPattern = @"(::|\*\*)([A-Z][a-z]{2,})(\1)";

            MatchCollection matchedEmojis = Regex.Matches(text, emojisPattern);

            Console.WriteLine($"{matchedEmojis.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in matchedEmojis)
            {
                int emojiCount = 0;

                for (int i = 2; i < emoji.ToString().Length - 2; i++)
                {
                    emojiCount += emoji.ToString()[i];
                }

                if (emojiCount > coolThresholdSum)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
