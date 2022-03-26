using System;
using System.Linq;

namespace _2._1.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string line = String.Empty;

            while ((line = Console.ReadLine()) != "end")
            {
                string[] lineParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = lineParts[0];

                if (command == "swap")
                {
                    int index1 = int.Parse(lineParts[1]);
                    int index2 = int.Parse(lineParts[2]);

                    int temp = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = temp;
                }
                else if (command == "multiply")
                {
                    int index1 = int.Parse(lineParts[1]);
                    int index2 = int.Parse(lineParts[2]);

                    numbers[index1] *= numbers[index2];
                }
                else if (command == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
