using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                List<string> lootItems = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = lootItems[0];

                if (command == "Loot")
                {
                    string[] items = lootItems.Skip(1).ToArray();

                    foreach (string item in items)
                    {
                        if (!treasureChest.Contains(item))
                        {
                            treasureChest.Insert(0, item);
                        }
                    }
                }
                else if (command == "Drop")
                {
                    int index = int.Parse(lootItems[1]);

                    if (index >= 0 && index < treasureChest.Count)
                    {
                        string loot = treasureChest[index];

                        treasureChest.RemoveAt(index);
                        treasureChest.Add(loot);
                    }
                }
                else if (command == "Steal")
                {
                    int count = int.Parse(lootItems[1]);
                    int index = treasureChest.Count - count;

                    string[] stealedLoots = null;

                    if (index >= 0)
                    {
                        stealedLoots = treasureChest.Skip(index).ToArray();
                        treasureChest.RemoveRange(index, count);
                    }
                    else
                    {
                        stealedLoots = treasureChest.ToArray();
                        treasureChest.Clear();
                    }

                    Console.WriteLine(string.Join(", ", stealedLoots));
                }
            }

            double average = GetAverage(treasureChest);

            if (treasureChest.Count != 0)
            {
                Console.WriteLine($"Average treasure gain: {average:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }

        static double GetAverage(List<string> treasureChest)
        {
            double sum = 0;

            foreach (string loot in treasureChest)
            {
                sum += loot.Length;
            }

            double average = sum / treasureChest.Count;

            return average;
        }
    }
}
