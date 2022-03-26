using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                int evenSum = 0;
                int oddSum = 0;

                int number = i;

                for (int position = 6; position >= 1; position--)
                {
                    int digit = number % 10;
                    number = number / 10;

                    if (position % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;   
                    }
                }

                if (evenSum == oddSum)
                {
                    Console.Write(i + " ");
                } 
            }
        }
    }
}
