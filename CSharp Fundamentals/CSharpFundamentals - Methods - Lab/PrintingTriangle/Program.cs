using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintNumbersFrom1(i);
            }

            for (int i = n - 1; i >= 1; i--)
            {
                PrintNumbersFrom1(i);
            }
        }

        static void PrintNumbersFrom1(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}
