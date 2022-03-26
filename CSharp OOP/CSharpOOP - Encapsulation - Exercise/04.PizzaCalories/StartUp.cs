using System;
using System.Linq;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine()
                .Split()
                .ToArray();

                Pizza pizza = new Pizza(pizzaInfo[1]);

                string[] doughInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                pizza.Dough = dough;

                string line = string.Empty;

                while ((line = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = line
                        .Split()
                        .ToArray();

                    Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }           
        }
    }
}
