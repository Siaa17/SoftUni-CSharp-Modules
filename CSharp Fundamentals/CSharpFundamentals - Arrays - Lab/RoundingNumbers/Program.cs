using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{Convert.ToDecimal(arr[i])} => {Math.Round(Convert.ToDecimal(arr[i]), MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
