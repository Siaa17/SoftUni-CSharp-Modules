using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string line = String.Empty;

            int currentPosition = 0;

            while ((line = Console.ReadLine()) != "Love!")
            {
                string[] jumpArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = jumpArgs[0];
                int length = int.Parse(jumpArgs[1]);  

                if (command == "Jump")
                {
                    currentPosition += length;
                }

                if (currentPosition >= neighborhood.Count)
                {
                    currentPosition = 0;
                }

                if (neighborhood[currentPosition] == 0)
                {
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                }
                else
                {
                    neighborhood[currentPosition] -= 2;

                    if (neighborhood[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }
            }

            Console.WriteLine($"Cupid's last position was {currentPosition}.");

            if (neighborhood.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int houseCount = 0;

                for (int i = 0; i < neighborhood.Count; i++)
                {
                    if (neighborhood[i] != 0)
                    {
                        houseCount++;
                    }
                }

                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}
