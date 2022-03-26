using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            FillQueue(n, pumps);

            int idxCounter = 0;

            while (true)
            {
                int totalPetrolAmount = 0;

                foreach (int[] pump in pumps)
                {
                    int petrolAmount = pump[0];
                    int distance = pump[1];

                    totalPetrolAmount += petrolAmount - distance;

                    if (totalPetrolAmount < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        idxCounter++;
                        break;
                    }
                }

                if (totalPetrolAmount >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(idxCounter);
        }

        private static void FillQueue(int n, Queue<int[]> pumps)
        {
            for (int i = 0; i < n; i++)
            {
                int[] currentPump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currentPump);
            }
        }
    }
}
