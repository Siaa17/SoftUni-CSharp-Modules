using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int cakePieces = width * length;

            string command = Console.ReadLine();
            bool isCakeEnough = true;

            while (command != "STOP")
            {
                int takenPieces = int.Parse(command);
                cakePieces -= takenPieces;

                if (cakePieces < 0)
                {
                    isCakeEnough = false;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isCakeEnough)
            {
                Console.WriteLine($"{cakePieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakePieces)} pieces more.");
            }
        }
    }
}
