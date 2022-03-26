using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesCount = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int daysCount = int.Parse(Console.ReadLine());

            double totalTime = pagesCount / pagesPerHour;
            double result = totalTime / daysCount;

            Console.WriteLine(result);

        }
    }
}
