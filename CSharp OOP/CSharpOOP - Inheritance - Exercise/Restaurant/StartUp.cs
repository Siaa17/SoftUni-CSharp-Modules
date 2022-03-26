using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Coffee coffee = new Coffee("Starbucks", 15);
            Console.WriteLine(coffee.Name);
            Console.WriteLine(coffee.Price);
            Console.WriteLine(coffee.Milliliters);
            Console.WriteLine(coffee.Caffeine);

            Cake cake = new Cake("Strawberry cheesecake");
            Console.WriteLine(cake.Name);
            Console.WriteLine(cake.Price);
            Console.WriteLine(cake.Grams);
            Console.WriteLine(cake.Calories);

            Fish fish = new Fish("Salmon", 25);
            Console.WriteLine(fish.Name);
            Console.WriteLine(fish.Price);
            Console.WriteLine(fish.Grams);
        }
    }
}
