using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> namesAndKms = new Dictionary<string, int>();

            string[] racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string namePattern = @"[A-Za-z]";
            string kmPattern = @"\d";

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection matchedLetters = Regex.Matches(input, namePattern);

                MatchCollection matchedDigits = Regex.Matches(input, kmPattern);

                string name = string.Concat(matchedLetters);

                int sumOfKm = matchedDigits
                    .Select(d => int.Parse(d.Value))
                    .Sum();

                if (racers.Contains(name))
                {
                    if (namesAndKms.ContainsKey(name))
                    {
                        namesAndKms[name] += sumOfKm;
                    }
                    else
                    {
                        namesAndKms.Add(name, sumOfKm);
                    }
                }
            }

            string[] sorted = namesAndKms
                    .OrderByDescending(k => k.Value)
                    .Take(3)
                    .Select(n => n.Key)
                    .ToArray();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }
    }
}
