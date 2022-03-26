using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            FillDictionary(wardrobe, n);

            string[] targetItem = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string targetColor = targetItem[0];
            string targetCloth = targetItem[1];

            PrintResult(wardrobe, targetColor, targetCloth);
        }

        static void PrintResult(Dictionary<string, Dictionary<string, int>> wardrobe, string targetColor, string targetCloth)
        {
            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (cloth, count) in clothes)
                {
                    if (color == targetColor && cloth == targetCloth)
                    {
                        Console.WriteLine($"* {targetCloth} - {count} (found!)");

                        continue;
                    }

                    Console.WriteLine($"* {cloth} - {count}");
                }
            }
        }

        static Dictionary<string, Dictionary<string, int>> FillDictionary(Dictionary<string, Dictionary<string, int>> wardrobe, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];

                string[] clothes = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (string cloth in clothes)
                {
                    if (wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth]++;
                    }
                    else
                    {
                        wardrobe[color].Add(cloth, 1);
                    }
                }
            }

            return wardrobe;
        }
    }
}
