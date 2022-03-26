using System;

namespace DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNums = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 1; i <= countNums; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    p1++;
                }
                if (number % 3 == 0)
                {
                    p2++;
                }
                if (number % 4 == 0)
                {
                    p3++;
                }
            }
           
            Console.WriteLine($"{p1 / countNums * 100:F2}%");
            Console.WriteLine($"{p2 / countNums * 100:F2}%");
            Console.WriteLine($"{p3 / countNums * 100:F2}%");
        }
    }
}
