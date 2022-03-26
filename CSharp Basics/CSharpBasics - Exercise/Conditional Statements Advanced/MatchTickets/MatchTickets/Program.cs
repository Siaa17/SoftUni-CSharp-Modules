using System;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int countPeople = int.Parse(Console.ReadLine());

            double totalPrice = 0;

            if (countPeople >= 1 && countPeople <= 4)
            {
                budget -= 0.75 * budget;
                if (category == "VIP")
                {
                    totalPrice = 499.99 * countPeople;
                }
                else if (category == "Normal")
                {
                    totalPrice = 249.99 * countPeople;
                }
            }
            else if (countPeople >= 5 && countPeople <= 9)
            {
                budget -= 0.60 * budget;
                if (category == "VIP")
                {
                    totalPrice = 499.99 * countPeople;
                }
                else if (category == "Normal")
                {
                    totalPrice = 249.99 * countPeople;
                }
            }
            else if (countPeople >= 10 && countPeople <= 24)
            {
                budget -= 0.50 * budget;
                if (category == "VIP")
                {
                    totalPrice = 499.99 * countPeople;
                }
                else if (category == "Normal")
                {
                    totalPrice = 249.99 * countPeople;
                }
            }
            else if (countPeople >= 25 && countPeople <= 49)
            {
                budget -= 0.40 * budget;
                if (category == "VIP")
                {
                    totalPrice = 499.99 * countPeople;
                }
                else if (category == "Normal")
                {
                    totalPrice = 249.99 * countPeople;
                }
            }
            else if (countPeople >= 50)
            {
                budget -= 0.25 * budget;
                if (category == "VIP")
                {
                    totalPrice = 499.99 * countPeople;
                }
                else if (category == "Normal")
                {
                    totalPrice = 249.99 * countPeople;
                }
            }
            if (budget >= totalPrice)
            {
                Console.WriteLine($"Yes! You have {budget - totalPrice:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:F2} leva.");
            }
        }
    }
}
