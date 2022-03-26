using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weapon = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] elements = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];
                string direction = elements[1];

                if (command == "Move")
                {
                    if (direction == "Left")
                    {
                        int index = int.Parse(elements[2]);

                        if (index - 1 >= 0 && index < weapon.Length)
                        {
                            string word = weapon[index];
                            weapon[index] = weapon[index - 1];
                            weapon[index - 1] = word;
                        }
                    }
                    else if (direction == "Right")
                    {
                        int index = int.Parse(elements[2]);

                        if (index >= 0 && index + 1 < weapon.Length)
                        {
                            string word = weapon[index];
                            weapon[index] = weapon[index + 1];
                            weapon[index + 1] = word;
                        }
                    }
                }
                else if (command == "Check")
                {
                    if (direction == "Even")
                    {
                        for (int i = 0; i < weapon.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write($"{weapon[i]} ");
                            }
                        }

                        Console.WriteLine();
                    }
                    else if (direction == "Odd")
                    {
                        for (int i = 0; i < weapon.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write($"{weapon[i]} ");
                            }
                        }

                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine($"You crafted {string.Join("", weapon)}!");
        }
    }
}