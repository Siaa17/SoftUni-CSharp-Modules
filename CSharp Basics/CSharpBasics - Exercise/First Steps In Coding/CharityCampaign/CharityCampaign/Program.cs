using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int chefs = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesPrice = 45 * 1.00;
            double wafflesPrice = 5.80;
            double pancakesPrice = 3.20;

            double totalSumDay = (cakes * cakesPrice + waffles * wafflesPrice + pancakes * pancakesPrice) * chefs;

            double totalSum = totalSumDay * days;
            double netSum = totalSum - totalSum / 8;
            
            Console.WriteLine(netSum);

        }
    }
}
