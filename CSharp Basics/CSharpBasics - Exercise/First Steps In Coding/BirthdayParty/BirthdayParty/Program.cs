using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rentHall = double.Parse(Console.ReadLine());

            double cake = rentHall * 0.2;
            double drinkables = cake - cake * 0.45;
            double animator = rentHall / 3;

            double totalBudget = rentHall + cake + drinkables + animator;

            Console.WriteLine(totalBudget);

        } 
    }
}

