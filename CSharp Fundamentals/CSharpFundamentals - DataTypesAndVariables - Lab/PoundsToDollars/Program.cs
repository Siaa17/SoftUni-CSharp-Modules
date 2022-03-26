using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal britishPounds = decimal.Parse(Console.ReadLine());

            decimal usDollars = britishPounds * 1.31M;

            Console.WriteLine($"{usDollars:F3}");
        }
    }
}
