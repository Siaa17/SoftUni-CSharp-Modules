using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] inputData = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = inputData[0];
                string pokemonName = inputData[1];
                string element = inputData[2];
                int health = int.Parse(inputData[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                Trainer currentTrainer = trainers[trainerName];

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                currentTrainer.Pokemons.Add(pokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string element = command;

                foreach (var currentTrainer in trainers)
                {
                    if (currentTrainer.Value.Pokemons.Any(p => p.Element == element))
                    {
                        currentTrainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in currentTrainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        currentTrainer.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            Dictionary<string, Trainer> sorted = trainers
                .OrderByDescending(t => t.Value.NumberOfBadges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sorted)
            {
                string trainerName = kvp.Key;
                int badges = kvp.Value.NumberOfBadges;
                int pokemons = kvp.Value.Pokemons.Count;

                Console.WriteLine($"{trainerName} {badges} {pokemons}");
            }
        }
    }
}
