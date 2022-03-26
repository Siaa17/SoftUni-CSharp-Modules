using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;
        private const double MinGrams = 1;
        private const double MaxGrams = 50;

        private readonly Dictionary<string, double> DefaultToppingTypes = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => this.toppingType;
            private set
            {
                if (!this.DefaultToppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [{MinGrams}..{MaxGrams}].");
                }

                this.weight = value;
            }
        }

        public double GetCaloriesPerGram => BaseCaloriesPerGram * this.Weight * this.DefaultToppingTypes[this.ToppingType.ToLower()];
    }
}
