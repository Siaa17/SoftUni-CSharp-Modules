using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegPricePerKg = double.Parse(Console.ReadLine());
            double fruitPricePerKg = double.Parse(Console.ReadLine());
            int vegKg = int.Parse(Console.ReadLine());
            int fruitKg = int.Parse(Console.ReadLine());

            double incomeInLv = (vegPricePerKg * vegKg) + (fruitPricePerKg * fruitKg);
            double incomeInEuros = incomeInLv / 1.94;
           
            Console.WriteLine($"{incomeInEuros:F2}");
                 
        }
    }
}
