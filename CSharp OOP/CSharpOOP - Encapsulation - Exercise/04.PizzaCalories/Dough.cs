using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private const double MinGrams = 1;
        private const double MaxGrams = 200;

        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 }
        };

        private readonly Dictionary<string, double> DefaultBakingTechniques = new Dictionary<string, double>()
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set 
            {
                if (!this.DefaultFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set 
            {
                if (!DefaultBakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value; 
            }
        }

        public double Weight
        {
            get => this.weight;
            private set 
            {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinGrams}..{MaxGrams}].");
                }

                this.weight = value; 
            }
        }

        public double GetCaloriesPerGram => BaseCaloriesPerGram * this.Weight * this.DefaultFlourTypes[this.FlourType.ToLower()] * this.DefaultBakingTechniques[this.BakingTechnique.ToLower()];
    }
}
