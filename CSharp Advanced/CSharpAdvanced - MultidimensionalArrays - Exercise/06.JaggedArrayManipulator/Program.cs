using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = currentRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                double[] firstRow = jaggedArray[row];
                double[] secondRow = jaggedArray[row + 1];

                if (firstRow.Length == secondRow.Length)
                {
                    jaggedArray[row] = firstRow.Select(e => e * 2).ToArray();
                    jaggedArray[row + 1] = secondRow.Select(e => e * 2).ToArray();
                }
                else
                {
                    jaggedArray[row] = firstRow.Select(e => e / 2).ToArray();
                    jaggedArray[row + 1] = secondRow.Select(e => e / 2).ToArray();
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (!IsValidIndexes(jaggedArray, row, col))
                {
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }

            PrintJaggedArray(jaggedArray);
        }

        static void PrintJaggedArray(double[][] jaggedArray)
        {
            foreach (double[] array in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }

        static bool IsValidIndexes(double[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
    }
}
