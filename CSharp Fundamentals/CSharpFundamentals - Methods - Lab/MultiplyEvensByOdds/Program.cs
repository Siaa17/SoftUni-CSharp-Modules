using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = Math.Abs(int.Parse(Console.ReadLine()));

            Console.WriteLine(GetMultiplyOfEvenAndOddDigits(inputNum));
        }

        static int GetMultiplyOfEvenAndOddDigits(int num)
        {
            int result = GetSumOfOddDigits(num) * GetSumOfEvenDigits(num);

            return result; 
        }

        static int GetSumOfEvenDigits(int number1)
        {  
            int evenSum = 0;

            while (number1 > 0)
            {
                int digit = number1 % 10;

                if (digit % 2 == 0)
                {
                    evenSum += digit;
                }

                number1 /= 10;
            }

            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;

            while (number > 0)
            {
                int digit = number % 10;

                if (digit % 2 == 1)
                {
                    oddSum += digit;
                }

                number /= 10;
            }

            return oddSum;
        }
    }
}
