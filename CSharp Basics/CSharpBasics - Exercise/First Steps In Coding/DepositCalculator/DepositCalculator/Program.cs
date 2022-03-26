using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int depositInMonths = int.Parse(Console.ReadLine());
            double interestPercent = double.Parse(Console.ReadLine());

            double interestForMonth = ((depositSum * interestPercent * 0.01) / 12);
            double result = depositSum + depositInMonths * interestForMonth;

            Console.WriteLine(result);

        }
    }
}
