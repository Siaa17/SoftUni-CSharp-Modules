using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beach = new char[rows][];

            ReadBeachMatrix(beach, rows);

            string input = string.Empty;

            int collectedTokens = 0;
            int opponentsTokens = 0;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commands[0];
                int currentRow = int.Parse(commands[1]);
                int currentCol = int.Parse(commands[2]);

                if (command == "Find")
                {
                    if (IsInMatrix(beach, currentRow, currentCol) && beach[currentRow][currentCol] == 'T')
                    {
                        collectedTokens++;
                        beach[currentRow][currentCol] = '-';
                    }
                }
                else if (command == "Opponent")
                {
                    string direction = commands[3];

                    if (CollectTokens(beach, currentRow, currentCol))
                    {
                        opponentsTokens++;

                        for (int i = 0; i < 3; i++)
                        {
                            if (direction == "up")
                            {
                                currentRow--;
                            }
                            else if (direction == "down")
                            {
                                currentRow++;
                            }
                            else if (direction == "left")
                            {
                                currentCol--;
                            }
                            else if (direction == "right")
                            {
                                currentCol++;
                            }

                            if (CollectTokens(beach, currentRow, currentCol))
                            {
                                opponentsTokens++;
                            }
                        }
                    }
                }
            }

            PrintBeachMatrix(beach);

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
        }

        private static void PrintBeachMatrix(char[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write(beach[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool CollectTokens(char[][] beach, int currentRow, int currentCol)
        {
            if (IsInMatrix(beach, currentRow, currentCol))
            {
                if (beach[currentRow][currentCol] == 'T')
                {
                    beach[currentRow][currentCol] = '-';
                    return true;
                }
            }

            return false;
        }       

        private static bool IsInMatrix(char[][] beach, int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentRow < beach.GetLength(0) && currentCol >= 0 && currentCol < beach[currentRow].Length;
        }

        private static void ReadBeachMatrix(char[][] beach, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                beach[row] = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(char.Parse)
                            .ToArray();
            }
        }
    }
}
