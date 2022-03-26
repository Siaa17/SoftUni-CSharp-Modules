using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> orcs = new Stack<int>();

            bool isGondorDestroyed = false;

            for (int i = 1; i <= wavesOfOrcs; i++)
            {
                orcs = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(extraPlate);
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {                  
                    if (orcs.Peek() > plates.Peek())
                    {
                        int woundedOrc = orcs.Pop() - plates.Dequeue();
                        orcs.Push(woundedOrc);
                    }
                    else if (orcs.Peek() < plates.Peek())
                    {
                        int damagedPlate = plates.Dequeue() - orcs.Pop();
                        plates.Enqueue(damagedPlate);

                        for (int j = 1; j < plates.Count; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }

                        //Another solution for the else if clause:
                        //int[] platesArr = plates.ToArray();
                        //platesArr[0] -= orcs.Pop();
                        //plates = new Queue<int>(platesArr);
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }

                    if (plates.Count == 0)
                    {
                        isGondorDestroyed = true;
                        break;
                    }
                }

                if (isGondorDestroyed)
                {
                    break;
                }
            }

            if (isGondorDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
