using System;

namespace FinalCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancersCount = int.Parse(Console.ReadLine());
            double pointsCount = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = Console.ReadLine();

            double expenses = 0;
            double amountWon = 0;

            switch (place)
            {
                case "Bulgaria":
                    switch (season)
                    {
                        case "summer":
                            expenses = 0.05;
                            break;
                        case "winter":
                            expenses = 0.08;
                            break;
                    }
                    break;
                case "Abroad":
                    switch (season)
                    {
                        case "summer":
                            expenses = 0.10;
                            break;
                        case "winter":
                            expenses = 0.15;
                            break;
                    }
                    break;
            }

            if (place == "Bulgaria")
            {
                amountWon = dancersCount * pointsCount;
            }
            else if (place == "Abroad")
            {
                amountWon = dancersCount * pointsCount;
                amountWon += amountWon * 0.50;
            }

            amountWon -= amountWon * expenses;
            double moneyForCharity = 0.75 * amountWon;
            double leftMoney = amountWon - moneyForCharity;
            double moneyPerDancer = leftMoney / dancersCount;

            Console.WriteLine($"Charity - {moneyForCharity:F2}");
            Console.WriteLine($"Money per dancer - {moneyPerDancer:F2}");
        }
    }
}
