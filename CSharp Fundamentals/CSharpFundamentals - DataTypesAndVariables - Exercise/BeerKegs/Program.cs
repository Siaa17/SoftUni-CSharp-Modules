﻿using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg = string.Empty;
            double biggestVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string currentKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestKeg = currentKeg;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
