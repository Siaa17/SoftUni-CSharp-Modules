using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int validCombinationsCount = 0;

            for (int num1 = 0; num1 <= number; num1++)
            {
                for (int num2 = 0; num2 <= number; num2++)
                {
                    for (int num3 = 0; num3 <= number; num3++)
                    {
                        if (num1 + num2 + num3 == number)
                        {
                            validCombinationsCount++;
                        }
                    }
                }
            }

            Console.WriteLine(validCombinationsCount);
        }
    }
}
