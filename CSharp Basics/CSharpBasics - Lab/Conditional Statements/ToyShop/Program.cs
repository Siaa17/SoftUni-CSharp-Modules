using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int numOfPuzzles = int.Parse(Console.ReadLine());
            int numOfDolls = int.Parse(Console.ReadLine());
            int numOfBears = int.Parse(Console.ReadLine());
            int numOfMinions = int.Parse(Console.ReadLine());
            int numOfTrucks = int.Parse(Console.ReadLine());

            double totalPrice = numOfPuzzles * 2.60 + numOfDolls * 3 +
                numOfBears * 4.10 + numOfMinions * 8.20 + numOfTrucks * 2;

            int numOfToys = numOfPuzzles + numOfDolls + numOfBears + numOfMinions + numOfTrucks;

            if (numOfToys >= 50)
            {
                totalPrice -= totalPrice * 0.25;
            }

            totalPrice -= totalPrice * 0.10;

            if (totalPrice >= holidayPrice)
            {
                Console.WriteLine($"Yes! {totalPrice - holidayPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {holidayPrice - totalPrice:F2} lv needed.");   
            }
        }
    }
}
