using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpaceVolume = width * length * height;

            string command = Console.ReadLine();

            int boxesCount = 0;
            bool isSpaceEnough = true;

            while (command != "Done")
            {
                boxesCount += int.Parse(command);
                
                if (freeSpaceVolume <= boxesCount)
                {
                    isSpaceEnough = false;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isSpaceEnough)
            {
                Console.WriteLine($"{freeSpaceVolume - boxesCount} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(freeSpaceVolume - boxesCount)} Cubic meters more.");
            }
        }
    }
}
