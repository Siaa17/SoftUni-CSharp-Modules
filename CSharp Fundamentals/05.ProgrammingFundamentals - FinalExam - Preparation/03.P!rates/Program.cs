using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> goldByTown = new Dictionary<string, int>();
            Dictionary<string, int> populationByTown = new Dictionary<string, int>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Sail")
            {
                string[] lineParts = line
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string town = lineParts[0];
                int population = int.Parse(lineParts[1]);
                int gold = int.Parse(lineParts[2]);

                if (goldByTown.ContainsKey(town))
                {
                    goldByTown[town] += gold;
                    populationByTown[town] += population;
                }
                else
                {
                    goldByTown.Add(town, gold);
                    populationByTown.Add(town, population);
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputParts = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputParts[0];
                string town = inputParts[1];

                if (command == "Plunder")
                {
                    int people = int.Parse(inputParts[2]);
                    int gold = int.Parse(inputParts[3]);

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    goldByTown[town] -= gold;
                    populationByTown[town] -= people;

                    if (goldByTown[town] == 0 || populationByTown[town] == 0)
                    {
                        goldByTown.Remove(town);
                        populationByTown.Remove(town);

                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(inputParts[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");

                        continue;
                    }
                    else
                    {
                        goldByTown[town] += gold;

                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {goldByTown[town]} gold.");
                    }
                }
            }

            Dictionary<string, int> sorted = goldByTown
                .OrderByDescending(t => t.Value)
                .ThenBy(t => t.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (goldByTown.Count != 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {goldByTown.Count} wealthy settlements to go to:");
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

            foreach (var kvp in sorted)
            {
                string town = kvp.Key;
                int people = populationByTown[town];
                int gold = kvp.Value;

                Console.WriteLine($"{town} -> Population: {people} citizens, Gold: {gold} kg");
            }
        }
    }
}
