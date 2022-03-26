using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            FillDitionary(symbols, text);

            PrintResult(symbols);
        }

        static void PrintResult(SortedDictionary<char, int> symbols)
        {
            foreach (KeyValuePair<char, int> symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }

        static SortedDictionary<char, int> FillDitionary(SortedDictionary<char, int> symbols, string text)
        {
            foreach (char symbol in text)
            {
                if (symbols.ContainsKey(symbol))
                {
                    symbols[symbol]++;
                }
                else
                {
                    symbols.Add(symbol, 1);
                }
            }

            return symbols;
        }
    }
}
