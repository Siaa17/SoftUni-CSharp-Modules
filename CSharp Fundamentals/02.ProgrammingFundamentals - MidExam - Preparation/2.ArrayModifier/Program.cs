using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string line = String.Empty;

            while ((line = Console.ReadLine()) != "end")
            {
                string[] elements = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];

                if (command == "swap")
                {
                    int firstIndex = int.Parse(elements[1]);
                    int secondIndex = int.Parse(elements[2]);

                    int number1 = listOfNumbers[firstIndex];
                    int number2 = listOfNumbers[secondIndex];

                    listOfNumbers.Insert(firstIndex, number2);
                    listOfNumbers.RemoveAt(firstIndex + 1);
                    listOfNumbers.Insert(secondIndex, number1);
                    listOfNumbers.RemoveAt(secondIndex + 1);
                }
                else if (command == "multiply")
                {
                    int firstIndex = int.Parse(elements[1]);
                    int secondIndex = int.Parse(elements[2]);

                    int result = listOfNumbers[firstIndex] * listOfNumbers[secondIndex];

                    listOfNumbers.Insert(firstIndex, result);
                    listOfNumbers.RemoveAt(firstIndex + 1);
                }
                else if (command == "decrease")
                {
                    for (int i = 0; i < listOfNumbers.Count; i++)
                    {
                        listOfNumbers[i]--;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", listOfNumbers));
        }
    }
}
