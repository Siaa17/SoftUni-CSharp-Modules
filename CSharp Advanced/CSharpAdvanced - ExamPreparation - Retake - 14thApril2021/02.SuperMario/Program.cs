using System;
using System.Linq;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int livesOfMario = int.Parse(Console.ReadLine());
            int rowsOfMaze = int.Parse(Console.ReadLine());

            char[][] maze = new char[rowsOfMaze][];

            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < rowsOfMaze; row++)
            {
                string currentRow = Console.ReadLine();

                maze[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    maze[row][col] = currentRow[col];

                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            bool isMissionCompleted = false;

            while (true)
            {
                string[] moves = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                char direction = char.Parse(moves[0]);
                int bowserRow = int.Parse(moves[1]);
                int bowserCol = int.Parse(moves[2]);

                maze[bowserRow][bowserCol] = 'B';

                livesOfMario--;

                switch (direction)
                {
                    case 'W':
                        if (marioRow - 1 < 0)
                        {
                            continue;
                        }

                        maze[marioRow][marioCol] = '-';
                        marioRow--;
                        break;
                    case 'S':
                        if (marioRow + 1 >= rowsOfMaze)
                        {
                            continue;
                        }

                        maze[marioRow][marioCol] = '-';
                        marioRow++;
                        break;
                    case 'A':
                        if (marioCol - 1 < 0)
                        {
                            continue;
                        }

                        maze[marioRow][marioCol] = '-';
                        marioCol--;
                        break;
                    case 'D':
                        if (marioCol + 1 >= maze[marioRow].Length)
                        {
                            continue;
                        }

                        maze[marioRow][marioCol] = '-';
                        marioCol++;
                        break;
                }

                if (livesOfMario <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    break;
                }

                if (maze[marioRow][marioCol] == 'B')
                {
                    livesOfMario -= 2;

                    if (livesOfMario <= 0)
                    {
                        maze[marioRow][marioCol] = 'X';
                        break;
                    }
                }
                else if (maze[marioRow][marioCol] == 'P')
                {
                    isMissionCompleted = true;
                    maze[marioRow][marioCol] = '-';
                    break;
                }

                maze[marioRow][marioCol] = 'M';
            }

            if (isMissionCompleted)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesOfMario}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    Console.Write(maze[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
