using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] foods = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(f => f.Length % 2 == 0)
                .ToArray();

            foreach (string item in foods)
            {
                Console.WriteLine(item);
            }
        }
    }
}
