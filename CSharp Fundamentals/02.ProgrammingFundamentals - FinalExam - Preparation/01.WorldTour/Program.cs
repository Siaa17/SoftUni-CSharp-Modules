using System;
using System.Linq;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] inputParts = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputParts[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(inputParts[1]);
                    string country = inputParts[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, country);
                    }

                    Console.WriteLine(stops);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(inputParts[1]);
                    int endIndex = int.Parse(inputParts[2]);

                    if (startIndex >= 0 && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(stops);
                }
                else if (command == "Switch")
                {
                    string oldCountry = inputParts[1];
                    string newCountry = inputParts[2];

                    if (stops.Contains(oldCountry))
                    {
                        stops = stops.Replace(oldCountry, newCountry);
                    }

                    Console.WriteLine(stops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
