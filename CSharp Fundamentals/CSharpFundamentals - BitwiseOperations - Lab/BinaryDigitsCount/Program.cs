using System;

namespace BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int binaryDigit = int.Parse(Console.ReadLine());

            int count = 0;

            while (number > 0)
            {
                int leftOver = number % 2;

                if (leftOver == binaryDigit)
                {
                    count++;
                }

                number /= 2;
            }

            Console.WriteLine(count);
        }
    }
}
