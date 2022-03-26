using System;

namespace CatFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int catsCount = int.Parse(Console.ReadLine());

            int smallCats = 0;
            int bigCats = 0;
            int hugeCats = 0;

            double totalCatsFood = 0;

            for (int cat = 1; cat <= catsCount; cat++)
            {
                double foodPerCatInGrams = double.Parse(Console.ReadLine());

                if (foodPerCatInGrams >= 100 && foodPerCatInGrams < 200)
                {
                    smallCats++;
                }
                else if (foodPerCatInGrams >= 200 && foodPerCatInGrams < 300)
                {
                    bigCats++;
                }
                else if (foodPerCatInGrams >= 300 && foodPerCatInGrams < 400)
                {
                    hugeCats++;
                }

                totalCatsFood += foodPerCatInGrams;
            }

            double foodPricePerDay = (totalCatsFood / 1000) * 12.45;

            Console.WriteLine($"Group 1: {smallCats} cats.");
            Console.WriteLine($"Group 2: {bigCats} cats.");
            Console.WriteLine($"Group 3: {hugeCats} cats.");
            Console.WriteLine($"Price for food per day: {foodPricePerDay:F2} lv.");
        }
    }
}
