using System;
using System.Linq;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string reverseInput = string.Concat(input.Reverse());

            Console.WriteLine(reverseInput);
        }
    }
}
