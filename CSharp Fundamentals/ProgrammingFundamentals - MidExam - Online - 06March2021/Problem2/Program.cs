using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayInput = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double budget = double.Parse(Console.ReadLine());

            List<double> newPrices = new List<double>();

            for (int i = 0; i < arrayInput.Length; i++)
            {
                string[] items = arrayInput[i]
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = items[0];
                double price = double.Parse(items[1]);

                double maxPrice = 0;

                switch (type)
                {
                    case "Clothes":
                        maxPrice = 50;
                        break;
                    case "Shoes":
                        maxPrice = 35;
                        break;
                    case "Accessories":
                        maxPrice = 20.50;
                        break;
                    default:
                        break;
                }

                if (budget >= price && price <= maxPrice)
                {
                    budget -= price;
                    newPrices.Add(price * 1.4);
                }
            }

            for (int i = 0; i < newPrices.Count; i++)
            {
                Console.Write($"{newPrices[i]:F2} ");
            }

            Console.WriteLine();

            budget += newPrices.Sum();

            double profit = newPrices.Sum() - newPrices.Sum() / 1.4;

            Console.WriteLine($"Profit: {profit:F2}");

            if (budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
