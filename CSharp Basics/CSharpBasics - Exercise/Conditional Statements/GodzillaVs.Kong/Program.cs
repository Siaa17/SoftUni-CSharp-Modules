using System;

namespace GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numOfPeople = int.Parse(Console.ReadLine());
            double priceOfClothing = double.Parse(Console.ReadLine());

            double totalPriceOfClothing = numOfPeople * priceOfClothing;

            budget -= 0.10 * budget;

            if (numOfPeople > 150)
            {
                totalPriceOfClothing -= totalPriceOfClothing * 0.10;
            }

            budget -= totalPriceOfClothing;

            if (budget >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget:F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(budget):F2} leva more.");
            }
        }   
    }
}
