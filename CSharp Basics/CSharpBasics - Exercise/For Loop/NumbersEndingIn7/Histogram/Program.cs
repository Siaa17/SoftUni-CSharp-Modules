using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNums = int.Parse(Console.ReadLine());

            double p1 = 0;   
            double p2 = 0;   
            double p3 = 0;   
            double p4 = 0;   
            double p5 = 0;   

            for (int i = 1; i <= countNums; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                if (nums < 200)
                {
                    p1++;
                }
                else if (nums < 400)
                {
                    p2++;
                }
                else if (nums < 600)
                {
                    p3++;
                }
                else if (nums < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }
            
            Console.WriteLine($"{p1 / countNums * 100:F2}%");
            Console.WriteLine($"{p2 / countNums * 100:F2}%");
            Console.WriteLine($"{p3 / countNums * 100:F2}%");
            Console.WriteLine($"{p4 / countNums * 100:F2}%");
            Console.WriteLine($"{p5 / countNums * 100:F2}%");
        }
    }
}
