using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte daysOfTrip = byte.Parse(Console.ReadLine());
            double budgetForWholeGroup = double.Parse(Console.ReadLine());
            byte countOfPeople = byte.Parse(Console.ReadLine());
            double fuelPricePerKm = double.Parse(Console.ReadLine());
            double foodExpensesPerPerson = double.Parse(Console.ReadLine());
            double roomPriceForNightPerPerson = double.Parse(Console.ReadLine());

            if (countOfPeople > 10)
            {
                roomPriceForNightPerPerson *= 0.75;
            }

            double currentExpenses = daysOfTrip * countOfPeople * (foodExpensesPerPerson + roomPriceForNightPerPerson);

            for (int i = 1; i <= daysOfTrip; i++)
            {
                double travelledDistanceInKmPerDay = double.Parse(Console.ReadLine());

                currentExpenses += travelledDistanceInKmPerDay * fuelPricePerKm;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    currentExpenses += currentExpenses * 0.4;
                }

                if (i % 7 == 0)
                {
                    currentExpenses -= currentExpenses / countOfPeople;
                }

                if (currentExpenses > budgetForWholeGroup)
                {
                    double neededMoney = currentExpenses - budgetForWholeGroup;

                    Console.WriteLine($"Not enough money to continue the trip. You need {neededMoney:F2}$ more.");

                    return; 
                }
            }                    

            double leftMoney = budgetForWholeGroup - currentExpenses;

            Console.WriteLine($"You have reached the destination. You have {leftMoney:F2}$ budget left.");
        }
    }
}
