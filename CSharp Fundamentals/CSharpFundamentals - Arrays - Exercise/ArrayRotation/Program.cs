using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int firstElement = array[0];

                int[] tempArray = new int[array.Length];

                for (int j = 1; j < array.Length; j++)
                {
                    tempArray[j - 1] = array[j];
                }

                tempArray[tempArray.Length - 1] = firstElement;
                array = tempArray;
            }

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
