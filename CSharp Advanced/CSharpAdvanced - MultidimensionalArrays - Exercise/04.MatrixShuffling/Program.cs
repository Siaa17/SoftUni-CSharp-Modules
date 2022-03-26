using System;
using System.Linq;

namespace _04.MatrixShuffling
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

            string[,] matrix = new string[rows, cols];

            FillMatrix(matrix);

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (!IsValidCommand(command, rows, cols))
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                string[] cmdData = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int firstRow = int.Parse(cmdData[1]);
                int firstCol = int.Parse(cmdData[2]);
                int secondRow = int.Parse(cmdData[3]);
                int secondCol = int.Parse(cmdData[4]);

                string temp = matrix[firstRow, firstCol];
                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = temp;

                PrintMatrix(matrix);
            }
        }

        static bool IsValidCommand(string command, int rows, int cols)
        {
            string[] cmdData = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (cmdData.Length == 5 && cmdData[0] == "swap" 
                && int.Parse(cmdData[1]) <= rows && int.Parse(cmdData[2]) <= cols
                && int.Parse(cmdData[3]) <= rows && int.Parse(cmdData[4]) <= cols)
            {
                return true;
            }

            return false;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
