using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int maxNum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;

                if (num > maxNum)
                {
                    maxNum = num;
                }
            }

            int sumWithoutMaxNumber = sum - maxNum;

            if (sumWithoutMaxNumber == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumWithoutMaxNumber}");
            }
            else
            {
                int difference = Math.Abs(maxNum - sumWithoutMaxNumber);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {difference}");
            }
        }
    }
}
