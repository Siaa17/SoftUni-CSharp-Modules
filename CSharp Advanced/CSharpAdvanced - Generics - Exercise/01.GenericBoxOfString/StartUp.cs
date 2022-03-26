using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //int countOfLines = int.Parse(Console.ReadLine());

            //for (int i = 0; i < countOfLines; i++)
            //{
            //    string input = Console.ReadLine();

            //    Box<string> box = new Box<string>(input);

            //    Console.WriteLine(box);
            //}

            int countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {
                int number = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(number);

                Console.WriteLine(box);
            }
        }
    }
}
