﻿using System;

namespace CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentLetter = input[i];
                Console.WriteLine(currentLetter);
            }
        }
    }
}
