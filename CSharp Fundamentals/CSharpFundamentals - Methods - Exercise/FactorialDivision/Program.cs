using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double firstFactorial = CalculateFactorial(firstNumber);
            double secondFactorial = CalculateFactorial(secondNumber);

            double result = firstFactorial / secondFactorial;
            Console.WriteLine($"{result:F2}");
        }

        static double CalculateFactorial(double num)
        {
            double factorial = 1;

            for (int i = 2; i <= num; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
