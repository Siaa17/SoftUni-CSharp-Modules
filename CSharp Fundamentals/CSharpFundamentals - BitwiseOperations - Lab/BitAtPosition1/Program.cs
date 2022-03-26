using System;

namespace BitAtPosition1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int bitAtPosition1 = 1;

            int result = (n >> bitAtPosition1) & 1;

            Console.WriteLine(result); 
        }
    }
}
