using System;
using System.Linq;

namespace _2.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleInQueue = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < lift.Length; i++)
            {
                int currentcabin = lift[i];

                if (4 - currentcabin > peopleInQueue)
                {
                    lift[i] += peopleInQueue;
                    peopleInQueue = 0;
                }
                else
                {
                    peopleInQueue -= (4 - currentcabin);
                    lift[i] += (4 - currentcabin);
                }
            }

            if (peopleInQueue == 0 && lift.Sum() < lift.Length * 4)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (peopleInQueue > 0 && lift.Sum() == lift.Length * 4)
            {
                Console.WriteLine($"There isn't enough space! {peopleInQueue} people in a queue!");
            }

            Console.WriteLine(string.Join(" ", lift));
        }
    }
}
