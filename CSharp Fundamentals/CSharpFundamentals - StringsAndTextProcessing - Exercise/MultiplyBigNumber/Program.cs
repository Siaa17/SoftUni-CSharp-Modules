using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int remainder = 0;

            StringBuilder result = new StringBuilder();

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int digit = bigNumber[i] - '0';

                remainder += digit * multiplier;

                if (remainder > 9)
                {
                    int remainderLastDigit = remainder % 10;
                    remainder /= 10;

                    result.Append(remainderLastDigit.ToString());
                }
                else
                {
                    result.Append(remainder.ToString());
                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                result.Append(remainder.ToString());
            }

            Console.WriteLine(string.Concat(result.ToString().Reverse()));
        }
    }
}
