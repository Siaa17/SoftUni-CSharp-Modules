using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            FillDictionary(numbers, n);

            PrintResult(numbers);
        }

        static void PrintResult(Dictionary<int, int> numbers)
        {
            int number = 0;

            foreach (KeyValuePair<int, int> num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    number = num.Key;
                }
            }

            Console.WriteLine(number);
        }

        static Dictionary<int, int> FillDictionary(Dictionary<int, int> numbers, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(num))
                {
                    numbers[num]++;
                }
                else
                {
                    numbers.Add(num, 1);
                }
            }

            return numbers;
        }
    }
}
