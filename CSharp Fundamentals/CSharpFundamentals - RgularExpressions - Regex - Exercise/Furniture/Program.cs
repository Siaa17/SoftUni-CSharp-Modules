using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            Regex expression = new Regex(pattern);

            List<string> furnitures = new List<string>();

            double totalMoney = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = expression.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                totalMoney += price * quantity;

                furnitures.Add(name);
            }

            Console.WriteLine("Bought furniture:");

            foreach (string furniture in furnitures)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalMoney:F2}");
        }
    }
}
