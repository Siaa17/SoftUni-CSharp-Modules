using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            while(heroes.Count != numberOfHeroes)
            {
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    BaseHero hero = null;

                    if (heroType == nameof(Druid))
                    {
                        hero = new Druid(heroName);
                    }
                    else if (heroType == nameof(Paladin))
                    {
                        hero = new Paladin(heroName);
                    }
                    else if (heroType == nameof(Rogue))
                    {
                        hero = new Rogue(heroName);
                    }
                    else if (heroType == nameof(Warrior))
                    {
                        hero = new Warrior(heroName);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }

                    heroes.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int totalHeroesPower = heroes.Sum(x => x.Power);

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            } 
        }
    }
}
