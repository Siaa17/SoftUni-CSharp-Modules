using System;

namespace AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());

            double sumNumbers = 0;
            double counter = 0;

            while (counter < number)
            {
                counter++;
                double currentNumber = double.Parse(Console.ReadLine());
                sumNumbers += currentNumber;
            }

            double average = sumNumbers / number;
            Console.WriteLine($"{average:F2}");
        }
    }
}
