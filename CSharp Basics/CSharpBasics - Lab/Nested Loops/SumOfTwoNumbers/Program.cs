using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int combinationsCount = 0;
            bool isCombinationFound = false;

            for (int firstNum = start; firstNum <= end; firstNum++)
            {
                for (int secondNum = start; secondNum <= end; secondNum++)
                {
                    combinationsCount++;
                    if (firstNum + secondNum == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combinationsCount} ({firstNum} + {secondNum} = {magicNum})");
                        isCombinationFound = true;
                        break;
                    }
                }
                if (isCombinationFound)
                {
                    break;
                }
            }

            if (!isCombinationFound)
            {
                Console.WriteLine($"{combinationsCount} combinations - neither equals {magicNum}"); 
            }
        }
    }
}
