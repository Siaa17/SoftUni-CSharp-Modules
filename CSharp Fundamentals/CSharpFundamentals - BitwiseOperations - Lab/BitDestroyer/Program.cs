using System;

namespace BitDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int shiftedNumber = 1 << p;

            int mask = ~shiftedNumber;

            int newNumber = n & mask;

            Console.WriteLine(newNumber);
        }
    }
}
