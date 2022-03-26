using System;

namespace MiningRig
{
    class Program
    {
        static void Main(string[] args)
        {
            int videoCardPrice = int.Parse(Console.ReadLine());
            int adapterPrice = int.Parse(Console.ReadLine());
            double consumedAmperagePerDay = double.Parse(Console.ReadLine());
            double profitPerDay = double.Parse(Console.ReadLine());

            double videoCardsTotalPrice = videoCardPrice * 13;
            double adaptersTotalPrice = adapterPrice * 13;
            double totalSpentMoney = videoCardsTotalPrice + adaptersTotalPrice + 1000;
            profitPerDay -= consumedAmperagePerDay;
            double totalProfitPerDay = 13 * profitPerDay;
            double daysToReturnMoney = totalSpentMoney / totalProfitPerDay;

            Console.WriteLine($"{totalSpentMoney}");
            Console.WriteLine($"{Math.Ceiling(daysToReturnMoney)}");
        }
    }
}
