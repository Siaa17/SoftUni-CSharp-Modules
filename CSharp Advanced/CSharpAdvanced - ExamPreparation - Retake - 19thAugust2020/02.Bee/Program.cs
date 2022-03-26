using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int beeRow = 0;
            int beeCol = 0;

            char[,] beeMatrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    beeMatrix[row, col] = currentRow[col];

                    if (beeMatrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int pollinatedFlowers = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                beeMatrix[beeRow, beeCol] = '.';

                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if (!IsPositionValid(beeRow, beeCol, size, size))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (beeMatrix[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }
                else if (beeMatrix[beeRow, beeCol] == 'O')
                {
                    beeMatrix[beeRow, beeCol] = '.';

                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);

                    if (!IsPositionValid(beeRow, beeCol, size, size))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (beeMatrix[beeRow, beeCol] == 'f')
                    {
                        pollinatedFlowers++;
                    }
                }

                beeMatrix[beeRow, beeCol] = 'B';
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                int flowersNeeded = 5 - pollinatedFlowers;

                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {flowersNeeded} flowers more");
            }

            for (int row = 0; row < beeMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < beeMatrix.GetLength(1); col++)
                {
                    Console.Write(beeMatrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            else if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            else if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            else if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
