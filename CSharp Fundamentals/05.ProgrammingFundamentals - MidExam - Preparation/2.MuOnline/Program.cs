using System;

namespace _2.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            int initialHealth = 100;
            int initialBitcoins = 0;
            bool isManaged = true;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] parts = rooms[i].Split();

                string command = parts[0];
                int number = int.Parse(parts[1]);

                if (command == "potion")
                {
                    int health = 0;

                    if (number + initialHealth <= 100)
                    {
                        health = number; 
                    }
                    else
                    {
                        health = 100 - initialHealth;
                    }

                    initialHealth += health;

                    Console.WriteLine($"You healed for {health} hp.");
                    Console.WriteLine($"Current health: {initialHealth} hp.");
                }
                else if (command == "chest")
                {
                    initialBitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    initialHealth -= number;

                    if (initialHealth > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        isManaged = false;
                        break;
                    }
                }
            }

            if (isManaged)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {initialBitcoins}");
                Console.WriteLine($"Health: {initialHealth}");
            }  
        }
    }
}
