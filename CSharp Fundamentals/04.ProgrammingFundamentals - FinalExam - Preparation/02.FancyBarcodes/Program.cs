using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"(@#+)([A-Z][A-Za-z0-9]{4,}[A-Z])(@#+)";
           
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                Regex regex = new Regex(pattern);

                Match match = regex.Match(barcode);

                if (match.Success)
                {
                    string concatDigits = string.Empty;

                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (char.IsDigit(barcode[j]))
                        {
                            concatDigits += barcode[j];
                        }
                    }

                    if (concatDigits == "")
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {concatDigits}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
