using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(RaiseNumToPower(number, power));
        }

        static double RaiseNumToPower(double num, int pow)
        {
            double result = Math.Pow(num, pow);
            
            return result;
        }
    }
}
