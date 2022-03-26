using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());

            string result = RepeatString(str, repeatCount);

            Console.WriteLine(result);
        }

        static string RepeatString(string str, int repeatCount)
        {
            string result = string.Empty;

            for (int i = 0; i < repeatCount; i++)
            {
                result += str;
            }

            return result;
        }
    }
}
