using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = Sum(firstNum, secondNum);
            int diff = Subtract(sum, thirdNum);

            Console.WriteLine(diff);
        }

        static int Sum(int first, int second)
        {
            return first + second;
        }

        static int Subtract(int first, int second)
        {
            return first - second;
        }
    }
}
