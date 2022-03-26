using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueOfBombEffects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

            Stack<int> stackOfBombCasing = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

            int daturaCounter = 0;
            int cherryCounter = 0;
            int smokeDecoyCounter = 0;

            while (queueOfBombEffects.Count > 0 && stackOfBombCasing.Count > 0)
            {
                if (daturaCounter >= 3 && cherryCounter >= 3 && smokeDecoyCounter >= 3)
                {
                    break;
                }

                int bombEffect = queueOfBombEffects.Peek();
                int bombCasing = stackOfBombCasing.Peek();

                int sum = bombEffect + bombCasing;

                bool isBombCreated = false;

                if (sum == 40)
                {
                    daturaCounter++;
                    isBombCreated = true;
                }
                else if (sum == 60)
                {
                    cherryCounter++;
                    isBombCreated = true;
                }
                else if (sum == 120)
                {
                    smokeDecoyCounter++;
                    isBombCreated = true;
                }

                if (isBombCreated)
                {
                    queueOfBombEffects.Dequeue();
                    stackOfBombCasing.Pop();
                }
                else
                {
                    stackOfBombCasing.Push(stackOfBombCasing.Pop() - 5);
                }
            }

            if (daturaCounter >= 3 && cherryCounter >= 3 && smokeDecoyCounter >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (queueOfBombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", queueOfBombEffects)}");
            }

            if (stackOfBombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", stackOfBombCasing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCounter}");
            Console.WriteLine($"Datura Bombs: {daturaCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyCounter}");
        }
    }
}
