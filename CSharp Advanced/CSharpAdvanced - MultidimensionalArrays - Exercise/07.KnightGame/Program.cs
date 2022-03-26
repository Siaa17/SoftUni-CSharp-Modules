using System;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];

            FillMatrix(chessBoard);

            int removedKnights = 0;
            int rowKnightKiller = 0;
            int colKnightKiller = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currentSymbol = chessBoard[row, col];

                        int knightAttacks = 0;

                        if (currentSymbol == 'K')
                        {
                            knightAttacks = GetAttacks(chessBoard, row, col, knightAttacks);

                            if (knightAttacks > maxAttacks)
                            {
                                maxAttacks = knightAttacks;
                                rowKnightKiller = row;
                                colKnightKiller = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    chessBoard[rowKnightKiller, colKnightKiller] = '0';

                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);

                    break;
                }
            }
        }

        static int GetAttacks(char[,] chessBoard, int row, int col, int knightAttacks)
        {
            if (IsInMatrix(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
            {
                knightAttacks++;
            }

            if (IsInMatrix(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
            {
                knightAttacks++;
            }

            if (IsInMatrix(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
            {
                knightAttacks++;
            }

            if (IsInMatrix(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
            {
                knightAttacks++;
            }

            if (IsInMatrix(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
            {
                knightAttacks++;
            }

            if (IsInMatrix(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
            {
                knightAttacks++;
            }

            if (IsInMatrix(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
            {
                knightAttacks++;
            }

            if (IsInMatrix(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
            {
                knightAttacks++;
            }

            return knightAttacks;
        }

        static bool IsInMatrix(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessBoard.GetLength(0) 
                && targetCol >= 0 && targetCol < chessBoard.GetLength(1); 
        }

        static void FillMatrix(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = currentRow[col];
                }
            }
        }
    }
}
 