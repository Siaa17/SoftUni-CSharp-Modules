using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueOfIngredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> stackOfFreshnessLvl = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> dishesValues = new Dictionary<string, int>();
            dishesValues.Add("Dipping sauce", 150);
            dishesValues.Add("Green salad", 250);
            dishesValues.Add("Chocolate cake", 300);
            dishesValues.Add("Lobster", 400);

            SortedDictionary<string, int> sortedDishes = new SortedDictionary<string, int>();
            sortedDishes.Add("Dipping sauce", 0);
            sortedDishes.Add("Green salad", 0);
            sortedDishes.Add("Chocolate cake", 0);
            sortedDishes.Add("Lobster", 0);

            while (queueOfIngredients.Count > 0 && stackOfFreshnessLvl.Count > 0)
            {
                if (queueOfIngredients.Peek() == 0)
                {
                    queueOfIngredients.Dequeue();
                    continue;
                }

                int product = queueOfIngredients.Peek() * stackOfFreshnessLvl.Peek();

                if (dishesValues.Any(d => d.Value == product))
                {
                    var currentDish = dishesValues.First(d => d.Value == product);
                    sortedDishes[currentDish.Key]++;

                    queueOfIngredients.Dequeue();
                    stackOfFreshnessLvl.Pop();
                }
                else
                {
                    stackOfFreshnessLvl.Pop();
                    queueOfIngredients.Enqueue(queueOfIngredients.Dequeue() + 5);
                }
            }  

            string result = sortedDishes.All(d => d.Value > 0) ? "Applause! The judges are fascinated by your dishes!" : "You were voted off. Better luck next year.";

            Console.WriteLine(result);

            if (queueOfIngredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {queueOfIngredients.Sum()}");
            }

            foreach (var dish in sortedDishes.Where(d => d.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
