using System;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            string input = "";
            string result = "";
            double dailyMoney = 0;
            int dailyWins = 0;
            int dailyLosts = 0;
            int totalWins = 0;
            int totalLosts = 0;
            double totalMoney = 0;

            for (int day = 1; day <= days; day++)
            {
                input = Console.ReadLine();

                while (input != "Finish")
                {
                    result = Console.ReadLine();

                    if (result == "win")
                    {
                        dailyMoney += 20;
                        dailyWins++;
                    }
                    else
                    {
                        dailyLosts++;
                    }
                    
                    input = Console.ReadLine();
                }

                if (dailyWins > dailyLosts)
                {
                    dailyMoney += dailyMoney * 0.1;
                }

                totalMoney += dailyMoney;
                totalWins += dailyWins;
                totalLosts += dailyLosts;
                dailyMoney = 0;
                dailyWins = 0;
                dailyLosts = 0;
            }

            if (totalWins > totalLosts)
            {
                totalMoney += totalMoney * 0.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:F2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:F2}");
            }
        }
    }
}
