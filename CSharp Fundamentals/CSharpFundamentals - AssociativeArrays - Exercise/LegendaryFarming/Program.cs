using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>()
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0},
            };

            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            bool isRunning = true;
            string winnerMaterial = string.Empty;

            while (isRunning)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < elements.Length; i += 2)
                {
                    int quantity = int.Parse(elements[i]);
                    string material = elements[i + 1].ToLower();

                    if (legendaryItems.ContainsKey(material))
                    {
                        legendaryItems[material] += quantity;

                        if (legendaryItems[material] >= 250)
                        {
                            winnerMaterial = material;
                            legendaryItems[material] -= 250;
                            isRunning = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(material))
                        {
                            junkItems[material] += quantity;
                        }
                        else
                        {
                            junkItems.Add(material, quantity);
                        }
                    }
                }
            }

            if (winnerMaterial == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (winnerMaterial == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (winnerMaterial == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            Dictionary<string, int> sortedLegendaryItems = legendaryItems
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, int> item in sortedLegendaryItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (KeyValuePair<string, int> item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
