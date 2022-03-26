using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private readonly List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => ingredients.Sum(a => a.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Contains(ingredient) &&
                this.CurrentAlcoholLevel < this.MaxAlcoholLevel &&
                ingredients.Count < this.Capacity)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (ingredients.Count > 0)
            {
                ingredients.Remove(ingredients.FirstOrDefault(i => i.Name == name));
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name) => ingredients.FirstOrDefault(i => i.Name == name);
        
        public Ingredient GetMostAlcoholicIngredient() => ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (Ingredient ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
