using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();   
            int countOfOvernights = int.Parse(Console.ReadLine());

            double totPriceForStudio = 0;
            double totPriceForApartment = 0;

            if (month == "May" || month == "October")
            {
                totPriceForStudio = countOfOvernights * 50;
                totPriceForApartment = countOfOvernights * 65;
                if (countOfOvernights > 7 && countOfOvernights <= 14)
                {
                    totPriceForStudio -= 0.05 * totPriceForStudio;
                }
                else if (countOfOvernights > 14)
                {
                    totPriceForStudio -= 0.30 * totPriceForStudio;
                }
            }
            else if (month == "June" || month == "September")
            {
                totPriceForStudio = countOfOvernights * 75.20;
                totPriceForApartment = countOfOvernights * 68.70;
                if (countOfOvernights > 14)
                {
                    totPriceForStudio -= 0.20 * totPriceForStudio;
                }
            }
            else if (month == "July" || month == "August")
            {
                totPriceForStudio = countOfOvernights * 76;
                totPriceForApartment = countOfOvernights * 77;
            }
            if (countOfOvernights > 14)
            {
                totPriceForApartment -= 0.10 * totPriceForApartment;
            }

            Console.WriteLine($"Apartment: {totPriceForApartment:F2} lv.");
            Console.WriteLine($"Studio: {totPriceForStudio:F2} lv.");
        }
    }
}
