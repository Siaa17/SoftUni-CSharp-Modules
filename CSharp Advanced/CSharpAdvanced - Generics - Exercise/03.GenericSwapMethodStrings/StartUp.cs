using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //List<string> listOfBoxes = new List<string>();

            //int countOfBoxes = int.Parse(Console.ReadLine());

            //for (int i = 0; i < countOfBoxes; i++)
            //{
            //    string input = Console.ReadLine();

            //    listOfBoxes.Add(input);
            //}

            //Box<string> box = new Box<string>(listOfBoxes);

            //int[] indexes = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //int firstIndex = indexes[0];
            //int secondIndex = indexes[1];

            //box.Swap(listOfBoxes, firstIndex, secondIndex);

            //Console.WriteLine(box);

            List<int> listOfBoxes = new List<int>();

            int countOfBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBoxes; i++)
            {
                int number = int.Parse(Console.ReadLine());

                listOfBoxes.Add(number);
            }

            Box<int> box = new Box<int>(listOfBoxes);

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            box.Swap(listOfBoxes, firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
