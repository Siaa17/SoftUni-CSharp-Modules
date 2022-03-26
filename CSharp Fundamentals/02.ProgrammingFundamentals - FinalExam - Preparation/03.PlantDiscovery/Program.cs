using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> rarityByPlant = new Dictionary<string, double>();
            Dictionary<string, List<double>> ratingsByPlant = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plantData = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plant = plantData[0];
                double rarity = double.Parse(plantData[1]);

                rarityByPlant[plant] = rarity;

                if (!ratingsByPlant.ContainsKey(plant))
                {
                    ratingsByPlant[plant] = new List<double>();
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] commandParts = input
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandParts[0];

                if (command == "Rate")
                {
                    string[] argsParts = commandParts[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    if (argsParts.Length != 2)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    string plant = argsParts[0];
                    double rating = double.Parse(argsParts[1]);

                    if (!ratingsByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    ratingsByPlant[plant].Add(rating);
                }
                else if (command == "Update")
                {
                    string[] argsParts = commandParts[1]
                       .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();

                    if (argsParts.Length != 2)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    string plant = argsParts[0];
                    double newRarity = double.Parse(argsParts[1]);

                    if (!rarityByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    rarityByPlant[plant] = newRarity;
                }
                else if (command == "Reset")
                {
                    string plant = commandParts[1];

                    if (!ratingsByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    ratingsByPlant[plant].Clear();
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Dictionary<string, double> sorted = rarityByPlant
                .OrderByDescending(r => r.Value)
                .ThenByDescending(r =>
                {
                    List<double> ratings = ratingsByPlant[r.Key];

                    if (ratings.Count == 0)
                    {
                        return 0;
                    }

                    return ratings.Average();
                })
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach (var kvp in sorted)
            {
                string plant = kvp.Key;
                double rarity = kvp.Value;
                double rating = 0;

                List<double> ratings = ratingsByPlant[kvp.Key];

                if (ratings.Count != 0)
                {
                    rating = ratings.Average();
                }

                Console.WriteLine($"- {plant}; Rarity: {rarity}; Rating: {rating:F2}");
            }
        }
    }
}
