using System;

namespace UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimitFirstNum = int.Parse(Console.ReadLine());
            int upperLimitSecondNum = int.Parse(Console.ReadLine());
            int upperLimitThirdNum = int.Parse(Console.ReadLine());

            for (int i = 2; i <= upperLimitFirstNum; i++)
            {
                for (int j = 2; j <= upperLimitSecondNum; j++)
                {
                    for (int k = 2; k <= upperLimitThirdNum; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                Console.WriteLine($"{i} {j} {k}");
                            }
                        }
                    }
                }
            }
        }
    }
}
