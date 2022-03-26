using System;
using System.Linq;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string currRow = Console.ReadLine();

                matrix[row] = new char[currRow.Length];

                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row][col] = currRow[col];

                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            bool isArmyReachesMordor = false;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string direction = input[0];
                int orcsRow = int.Parse(input[1]);
                int orcsCol = int.Parse(input[2]);

                matrix[orcsRow][orcsCol] = 'O';

                armyArmor--;

                switch (direction)
                {
                    case "up":
                        if (armyRow - 1 < 0)
                        {
                            continue;
                        }

                        matrix[armyRow][armyCol] = '-';
                        armyRow--;
                        break;
                    case "down":
                        if (armyRow + 1 >= rows)
                        {
                            continue;
                        }

                        matrix[armyRow][armyCol] = '-';
                        armyRow++;
                        break;
                    case "left":
                        if (armyCol - 1 < 0)
                        {
                            continue;
                        }

                        matrix[armyRow][armyCol] = '-';
                        armyCol--;
                        break;
                    case "right":
                        if (armyCol + 1 >= matrix[armyRow].Length)
                        {
                            continue;
                        }

                        matrix[armyRow][armyCol] = '-';
                        armyCol++;
                        break;
                }

                if (armyArmor <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    break;
                }

                if (matrix[armyRow][armyCol] == 'O')
                {
                    armyArmor -= 2;

                    if (armyArmor <= 0)
                    {
                        matrix[armyRow][armyCol] = 'X';
                        break;
                    }
                }
                else if (matrix[armyRow][armyCol] == 'M')
                {
                    isArmyReachesMordor = true;
                    matrix[armyRow][armyCol] = '-';
                    break;
                }

                matrix[armyRow][armyCol] = 'A';
            }

            if (isArmyReachesMordor)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
