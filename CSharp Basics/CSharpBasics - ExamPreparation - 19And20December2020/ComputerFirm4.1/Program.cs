using System;

namespace ComputerFirm4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int computerModelsCount = int.Parse(Console.ReadLine());

            double actualSales = 0;
            double ratingSum = 0;

            for (int i = 1; i <= computerModelsCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                int rating = number % 10;
                int potentialSales = number / 10;

                switch (rating)
                {
                    case 2:
                        actualSales += 0 * potentialSales;
                        break;
                    case 3:
                        actualSales += 0.5 * potentialSales;
                        break;
                    case 4:
                        actualSales += 0.7 * potentialSales;
                        break;
                    case 5:
                        actualSales += 0.85 * potentialSales;
                        break;
                    case 6:
                        actualSales += 1 * potentialSales;
                        break;
                }

                ratingSum += rating;
            }

            Console.WriteLine($"{actualSales:F2}");
            Console.WriteLine($"{ratingSum / computerModelsCount:F2}");
        }
    }
}
