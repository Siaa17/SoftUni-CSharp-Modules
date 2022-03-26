using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^[^|$%.]*%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)[^|$%.]*\$$";

            Regex regex = new Regex(pattern);

            double income = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match matchedText = regex.Match(input);

                if (!matchedText.Success)
                {
                    continue;
                }

                string customer = matchedText.Groups["customer"].Value;
                string product = matchedText.Groups["product"].Value;
                int quantity = int.Parse(matchedText.Groups["quantity"].Value);
                double price = double.Parse(matchedText.Groups["price"].Value);

                double totalPrice = quantity * price;

                Console.WriteLine($"{customer}: {product} - {totalPrice:F2}");

                income += totalPrice;
            }

            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
