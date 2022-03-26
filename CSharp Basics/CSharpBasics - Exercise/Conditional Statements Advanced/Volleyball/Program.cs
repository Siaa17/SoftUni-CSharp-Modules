using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsInHometown = int.Parse(Console.ReadLine());

            double weekendsInSofia = 48 - weekendsInHometown;
            weekendsInSofia *= 3.0/4.0;
            double gamesInHolidays = holidays * 2.0/3.0;
            double totalGames = weekendsInSofia + weekendsInHometown + gamesInHolidays;

            if (year == "leap")
            {
                totalGames += totalGames * 0.15;
            }

            Console.WriteLine($"{Math.Floor(totalGames)}");
        }
    }
}
