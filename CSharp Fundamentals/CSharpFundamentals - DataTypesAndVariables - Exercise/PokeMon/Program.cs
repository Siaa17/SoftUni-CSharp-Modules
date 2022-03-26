using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int originalN = n;
            int pokeTargets = 0;

            while (n >= m)
            {
                n -= m;
                pokeTargets++;

                if (n == originalN / 2 && y > 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(pokeTargets);
        }
    }
}
