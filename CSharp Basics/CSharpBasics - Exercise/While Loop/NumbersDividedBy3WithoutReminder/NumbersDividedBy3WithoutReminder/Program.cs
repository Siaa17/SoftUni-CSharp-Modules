using System;

namespace NumbersDividedBy3WithoutReminder
{
    class Program
    {
        static void Main(string[] args)
        { 
            int number = 1;

            while (number < 100)
            {
                number++;

                if (number % 3 == 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
