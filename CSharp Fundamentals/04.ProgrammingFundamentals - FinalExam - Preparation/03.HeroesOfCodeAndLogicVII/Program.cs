using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> hitPtsByHero = new Dictionary<string, int>();
            Dictionary<string, int> manaPtsByHero = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroesData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string hero = heroesData[0];
                int hitPoints = int.Parse(heroesData[1]);
                int manaPoints = int.Parse(heroesData[2]);

                hitPtsByHero.Add(hero, hitPoints);
                manaPtsByHero.Add(hero, manaPoints);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputParts = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputParts[0];
                string hero = inputParts[1];

                if (command == "CastSpell")
                {
                    int mpNeeded = int.Parse(inputParts[2]);
                    string spellName = inputParts[3];

                    if (manaPtsByHero[hero] >= mpNeeded)
                    {
                        manaPtsByHero[hero] -= mpNeeded;

                        Console.WriteLine($"{hero} has successfully cast {spellName} and now has {manaPtsByHero[hero]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(inputParts[2]);
                    string attacker = inputParts[3];

                    hitPtsByHero[hero] -= damage;

                    if (hitPtsByHero[hero] > 0)
                    {
                        Console.WriteLine($"{hero} was hit for {damage} HP by {attacker} and now has {hitPtsByHero[hero]} HP left!");
                    }
                    else
                    {
                        hitPtsByHero.Remove(hero);
                        manaPtsByHero.Remove(hero);

                        Console.WriteLine($"{hero} has been killed by {attacker}!");
                    }
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(inputParts[2]);
                    int maxValueMp = 200;

                    if (amount + manaPtsByHero[hero] > maxValueMp)
                    {
                        amount = maxValueMp - manaPtsByHero[hero];
                    }

                    manaPtsByHero[hero] += amount;

                    Console.WriteLine($"{hero} recharged for {amount} MP!");
                }
                else if (command == "Heal")
                {
                    int amount = int.Parse(inputParts[2]);
                    int maxValueHp = 100;

                    if (amount + hitPtsByHero[hero] > maxValueHp)
                    {
                        amount = maxValueHp - hitPtsByHero[hero];
                    }

                    hitPtsByHero[hero] += amount;

                    Console.WriteLine($"{hero} healed for {amount} HP!");
                }
            }

            Dictionary<string, int> sorted = hitPtsByHero
                .OrderByDescending(h => h.Value)
                .ThenBy(h => h.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                string hero = kvp.Key;
                int currentHp = kvp.Value;
                int currentMp = manaPtsByHero[hero];

                Console.WriteLine(hero);
                Console.WriteLine($"  HP: {currentHp}");
                Console.WriteLine($"  MP: {currentMp}");  
            }
        }
    }
}
