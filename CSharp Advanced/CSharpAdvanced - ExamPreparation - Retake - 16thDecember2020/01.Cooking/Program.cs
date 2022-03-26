using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> foodValues = new Dictionary<string, int>();
            foodValues.Add("Bread", 25);
            foodValues.Add("Cake", 50);
            foodValues.Add("Pastry", 75);
            foodValues.Add("Fruit Pie", 100);

            SortedDictionary<string, int> sortedFood = new SortedDictionary<string, int>();
            sortedFood.Add("Bread", 0);
            sortedFood.Add("Cake", 0);
            sortedFood.Add("Pastry", 0);
            sortedFood.Add("Fruit Pie", 0);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquids.Peek() + ingredients.Peek();

                if (foodValues.Any(f => f.Value == sum))
                {
                    var currentFood = foodValues.First(f => f.Value == sum);
                    sortedFood[currentFood.Key]++;

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }  
            }

            string result = sortedFood.All(f => f.Value > 0) ? "Wohoo! You succeeded in cooking all the food!" : "Ugh, what a pity! You didn't have enough materials to cook everything.";
            Console.WriteLine(result);

            string secondResult = $"Liquids left: {(liquids.Count > 0 ? string.Join(", ", liquids) : "none")}";
            Console.WriteLine(secondResult);

            string thirdResult = $"Ingredients left: {(ingredients.Count > 0 ? string.Join(", ", ingredients) : "none")}";
            Console.WriteLine(thirdResult);

            foreach (var food in sortedFood)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
