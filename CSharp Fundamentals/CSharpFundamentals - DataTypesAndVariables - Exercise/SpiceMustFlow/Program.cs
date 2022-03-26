using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            if (startingYield < 100)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);
            }
            else
            {
                int days = 0;
                long totalExtractedSpice = 0;
                
                while (startingYield >= 100)
                {
                    days++;
                    totalExtractedSpice += startingYield - 26;
                    startingYield -= 10;
                }

                totalExtractedSpice -= 26;

                Console.WriteLine(days);
                Console.WriteLine(totalExtractedSpice);
            }
        }
    }
}
