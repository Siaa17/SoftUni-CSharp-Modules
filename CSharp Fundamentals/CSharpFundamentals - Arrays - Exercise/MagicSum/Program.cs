using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    int rightNumber = array[j];

                    if (currentNumber + rightNumber == magicSum)
                    {
                        Console.WriteLine($"{currentNumber} {rightNumber}");
                        break;
                    }
                }
            }
        }
    }
}
