using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueGuests = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> stackPlates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int wastedGrams = 0;

            while (queueGuests.Count > 0 && stackPlates.Count > 0)
            {
                if (queueGuests.Peek() <= 0)
                {
                    queueGuests.Dequeue();
                }

                if (queueGuests.Peek() > stackPlates.Peek())
                {
                    while (queueGuests.Peek() > 0)
                    {
                        queueGuests.Enqueue(queueGuests.Dequeue() - stackPlates.Pop());

                        for (int i = 0; i < queueGuests.Count - 1; i++)
                        {
                            queueGuests.Enqueue(queueGuests.Dequeue());
                        }
                    }
                }
                else if (queueGuests.Peek() <= stackPlates.Peek())
                {
                    wastedGrams += stackPlates.Pop() - queueGuests.Dequeue();
                }
            }

            if (stackPlates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", stackPlates)}");
            }
            else if (queueGuests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", queueGuests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedGrams}");
        }
    }
}
