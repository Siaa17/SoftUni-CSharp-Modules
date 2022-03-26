using System;
using System.ComponentModel;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberriesKg = double.Parse(Console.ReadLine());
            double strawberriesKg = double.Parse(Console.ReadLine());

            double raspberriesPrice = strawberriesPrice / 2;
            double orangesPrices = raspberriesPrice * 0.60;
            double bananasPrice = raspberriesPrice * 0.20;

            double totalSum = (strawberriesPrice * strawberriesKg) + (raspberriesPrice * raspberriesKg) + (orangesPrices * orangesKg) + (bananasPrice * bananasKg);

            Console.WriteLine($"{totalSum:F2}");

        }
    }
}
