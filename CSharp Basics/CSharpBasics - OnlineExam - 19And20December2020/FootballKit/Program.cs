using System;

namespace FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double amountToWin = double.Parse(Console.ReadLine());

            double shortsPrice = tshirtPrice * 0.75;
            double socksPrice = shortsPrice * 0.20;
            double buttonsPrice = (tshirtPrice + shortsPrice) * 2;

            double totalPrice = tshirtPrice + shortsPrice + socksPrice + buttonsPrice;
            totalPrice -= totalPrice * 0.15;

            if (totalPrice >= amountToWin)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalPrice:F2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {amountToWin - totalPrice:F2} lv. more.");
            }
        }
    }
}
