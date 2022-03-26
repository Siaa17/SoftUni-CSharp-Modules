using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();

            string pattern = @"([=\/])([A-Z][A-Za-z]{2,})\1";

            Regex regex = new Regex(pattern);

            MatchCollection matchedPlaces = regex.Matches(places);

            List<string> allDestinations = new List<string>();

            int travelPoints = 0;

            foreach (Match match in matchedPlaces)
            {
                string destination = match.Groups[2].Value;

                travelPoints += destination.Length;

                allDestinations.Add(destination);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", allDestinations)}");

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
