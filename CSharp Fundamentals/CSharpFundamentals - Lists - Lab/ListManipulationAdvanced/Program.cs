using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = String.Empty;

            bool isChanged = false;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(command[1]);
                        numbers.Add(numberToAdd);
                        isChanged = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(command[1]);
                        numbers.Remove(numberToRemove);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(command[1]);
                        numbers.RemoveAt(indexToRemove);
                        isChanged = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(command[1]);
                        int indexToInsert = int.Parse(command[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        isChanged = true;
                        break;
                    case "Contains":
                        int numberToContains = int.Parse(command[1]);
                        if(numbers.Contains(numberToContains))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        int numberToFilter = int.Parse(command[2]);
                        switch (command[1])
                        {
                            case ">":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n > numberToFilter)));
                                break;
                            case ">=":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n >= numberToFilter)));
                                break;
                            case "<":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n < numberToFilter)));
                                break;
                            case "<=":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n <= numberToFilter)));
                                break;
                        }
                        break;
                }
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        } 
    }
}
