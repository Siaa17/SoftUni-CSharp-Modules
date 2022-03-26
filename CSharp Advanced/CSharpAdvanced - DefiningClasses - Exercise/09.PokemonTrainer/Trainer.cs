using System;
using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string trainerName)
        {
            this.TrainerName = trainerName;
            this.NumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string TrainerName { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
