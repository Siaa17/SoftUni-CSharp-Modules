using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floorsCount = int.Parse(Console.ReadLine());
            int roomsCount = int.Parse(Console.ReadLine());

            for (int f = floorsCount; f >= 1; f--)
            {
                for (int r = 0; r < roomsCount; r++)
                {
                    if (f == floorsCount)
                    {
                        Console.Write($"L{f}{r} ");
                    }
                    else if (f % 2 == 0)
                    {
                        Console.Write($"O{f}{r} ");
                    }
                    else
                    {
                        Console.Write($"A{f}{r} ");
                    }
                }

                Console.WriteLine();
            } 
        }
    }
}
