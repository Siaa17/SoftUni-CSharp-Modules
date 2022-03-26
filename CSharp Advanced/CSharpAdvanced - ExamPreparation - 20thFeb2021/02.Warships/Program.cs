using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            string[] attackCommands = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            int totalCountShipsDestroyed = 0;
            bool isGameWon = false;
            string winner = string.Empty;

            for (int i = 0; i < attackCommands.Length; i++)
            {
                int[] currentCoordinates = attackCommands[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currRow = currentCoordinates[0];
                int currCol = currentCoordinates[1];

                if (currRow < 0 || currRow >= size || currCol < 0 || currCol >= size)
                {
                    continue;
                }

                if (matrix[currRow, currCol] == '<')
                {
                    firstPlayerShips--;
                    matrix[currRow, currCol] = 'X';
                    totalCountShipsDestroyed++;
                }
                else if (matrix[currRow, currCol] == '>')
                {
                    secondPlayerShips--;
                    matrix[currRow, currCol] = 'X';
                    totalCountShipsDestroyed++;
                }
                else if (matrix[currRow, currCol] == '#')
                {
                    for (int row = currRow - 1; row <= currRow + 1; row++)
                    {
                        for (int col = currCol - 1; col <= currCol + 1; col++)
                        {
                            if (row >= 0 && row < size && col >= 0 && col < size)
                            {
                                if (matrix[row, col] == '<')
                                {
                                    firstPlayerShips--;
                                    matrix[row, col] = 'X';
                                    totalCountShipsDestroyed++;
                                }
                                else if (matrix[row, col] == '>')
                                {
                                    secondPlayerShips--;
                                    matrix[row, col] = 'X';
                                    totalCountShipsDestroyed++;
                                }
                            }
                        }
                    }
                }

                if (firstPlayerShips == 0)
                {
                    isGameWon = true;
                    winner = "Two";
                    break;
                }
                else if (secondPlayerShips == 0)
                {
                    isGameWon = true;
                    winner = "One";
                    break;
                }
            }

            if (isGameWon)
            {
                Console.WriteLine($"Player {winner} has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }
    }
}
