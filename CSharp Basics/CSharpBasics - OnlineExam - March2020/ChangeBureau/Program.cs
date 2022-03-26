using System;

namespace ChangeBureau1
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double chineseYuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double euroForVacation = (bitcoins * 1168 + (chineseYuans * 0.15) * 1.76) / 1.95;

            commission *= 0.01;
            double commissionFee = commission * euroForVacation;
            double result = euroForVacation - commissionFee;

            Console.WriteLine($"{result:F2}");
        }
    }
}
