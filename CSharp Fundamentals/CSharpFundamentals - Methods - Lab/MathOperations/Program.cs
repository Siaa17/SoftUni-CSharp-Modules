using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double result = 0;

            switch (operation)
            {
                case '+':
                   result = Addition(firstNumber, secondNumber);  
                    break;
                case '*':
                    result = Multiplication(firstNumber, secondNumber); 
                    break;
                case '-':
                    result = Subtraction(firstNumber, secondNumber);
                    break;
                case '/':
                    result = Division(firstNumber, secondNumber); 
                    break;
            }

            Console.WriteLine(Math.Round(result, 2));
        }
        
        static double Addition(double a, double b)
        {
            return a + b;
        }

        static double Multiplication(double a, double b)
        {
            return a * b;
        }

        static double Subtraction(double a, double b)
        {
            return a - b;
        }

        static double Division(double a, double b)
        {
            return a / b;
        }
    }
}
