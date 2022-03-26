using System;

namespace _02.Re_Volt
{
    public class Position
    {
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool IsInMatrix(int rowLength, int colLength)
        {
            if (Row < 0 || Row >= rowLength)
            {
                return false;
            }
            else if (Col < 0 || Col >= colLength)
            {
                return false;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            ReadMatrix(matrix, size);

            Position player = GetPlayerPosition(matrix);

            matrix[player.Row, player.Col] = '-';

            for (int i = 0; i < countOfCommands; i++)
            {
                string direction = Console.ReadLine();

                MovePlayer(size, player, direction);

                if (matrix[player.Row, player.Col] == 'B')
                {
                    MovePlayer(size, player, direction);
                }
                else if (matrix[player.Row, player.Col] == 'T')
                {
                    Position playerDirection = GetDirection(direction);
                    player.Row += playerDirection.Row * - 1;
                    player.Col += playerDirection.Col * - 1;
                }
                else if (matrix[player.Row, player.Col] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[player.Row, player.Col] = 'f';
                    PrintMatrix(matrix);
                    return;
                }
            }

            Console.WriteLine("Player lost!");

            matrix[player.Row, player.Col] = 'f';

            PrintMatrix(matrix);
        }

        private static Position GetDirection(string direction)
        {
            int row = 0;
            int col = 0;

            if (direction == "up")
            {
                row = - 1;
            }
            else if (direction == "down")
            {
                row = 1;
            }
            else if (direction == "left")
            {
                col = -1;
            }
            else if (direction == "right")
            {
                col = 1;
            }

            return new Position(row, col);
        }

        private static Position MovePlayer(int size, Position player, string direction)
        {
            if (direction == "up")
            {
                player.Row--;

                if (!player.IsInMatrix(size, size))
                {
                    player.Row = size - 1;
                }
            }
            else if (direction == "down")
            {
                player.Row++;

                if (!player.IsInMatrix(size, size))
                {
                    player.Row = 0;
                }
            }
            else if (direction == "left")
            {
                player.Col--;

                if (!player.IsInMatrix(size, size))
                {
                    player.Col = size - 1;
                }
            }
            else if (direction == "right")
            {
                player.Col++;

                if (!player.IsInMatrix(size, size))
                {
                    player.Col = 0;
                }
            }

            return player;
        }

        private static Position GetPlayerPosition(char[,] matrix)
        {
            Position position = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
        }

        private static void ReadMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
