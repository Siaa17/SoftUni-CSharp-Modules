using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] garden = new int[rows, cols];

            for (int row = 0; row <= rows - 1; row++)
            {
                for (int col = 0; col <= cols - 1; col++)
                {
                    garden[row, col] = 0;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {               
                int[] currentPosition = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currRow = currentPosition[0];
                int currCol = currentPosition[1];

                if (currRow < 0 || currRow >= garden.GetLength(0) &&
                    currCol < 0 || currCol >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");

                    continue;
                }

                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[currRow, i]++;
                }

                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[j, currCol]++;
                }

                garden[currRow, currCol]--;
            }

            for (int row = 0; row <= rows - 1; row++)
            {
                for (int col = 0; col <= cols - 1; col++)
                {
                    Console.Write(garden[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
