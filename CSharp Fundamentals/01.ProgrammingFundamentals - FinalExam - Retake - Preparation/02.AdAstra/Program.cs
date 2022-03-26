using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([#|])(?<food>[A-Za-z\s]+)\1(?<expDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,4}|10000)\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            int calories = matches
                   .Select(c => int.Parse(c.Groups["calories"].Value))
                   .Sum();

            int days = calories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["food"].Value}, Best before: {match.Groups["expDate"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
