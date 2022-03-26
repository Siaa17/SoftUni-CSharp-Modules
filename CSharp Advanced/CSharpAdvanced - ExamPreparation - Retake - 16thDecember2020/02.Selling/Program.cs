using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int myRow = 0;
            int myCol = 0;
            int firstPillarRow = -1;
            int firstPillarCol = -1;
            int secondPillarRow = -1;
            int secondPillarCol = -1;

            char[,] bakery = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    bakery[row, col] = currentRow[col];

                    if (bakery[row, col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }
                    else if (bakery[row, col] == 'O')
                    {
                        if (firstPillarRow == -1)
                        {
                            firstPillarRow = row;
                            firstPillarCol = col;
                        }
                        else
                        {
                            secondPillarRow = row;
                            secondPillarCol = col;
                        }
                    }
                }
            }

            int money = 0;

            while (true)
            {
                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    bakery[myRow, myCol] = 'S';
                    break;
                }

                string direction = Console.ReadLine();

                bakery[myRow, myCol] = '-';

                if (direction == "up")
                {
                    myRow--;
                }
                else if (direction == "down")
                {
                    myRow++;
                }
                else if (direction == "left")
                {
                    myCol--;
                }
                else if (direction == "right")
                {
                    myCol++;
                }

                if (!IsInMatrix(bakery, myRow, myCol))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                char currentChar = bakery[myRow, myCol];

                if (bakery[myRow, myCol] == 'O')
                {
                    bakery[myRow, myCol] = '-';

                    if (firstPillarRow == myRow && firstPillarCol == myCol)
                    {
                        myRow = secondPillarRow;
                        myCol = secondPillarCol;
                    }
                    else
                    {
                        myRow = firstPillarRow;
                        myCol = firstPillarCol;
                    }

                    bakery[myRow, myCol] = 'S';
                }
                else if (char.IsDigit(currentChar))
                {
                    money += int.Parse(currentChar.ToString());
                    bakery[myRow, myCol] = 'S';
                }
                
                bakery[myRow, myCol] = '-';
            }

            Console.WriteLine($"Money: {money}");

            PrintMatrix(bakery);
        }

        public static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }
            else if (col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public static void PrintMatrix(char[,] matrix)
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
