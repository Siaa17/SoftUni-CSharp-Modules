using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsCount = int.Parse(Console.ReadLine());
            int animalsCount = int.Parse(Console.ReadLine());

            double totalSum = (dogsCount * 2.50) + (animalsCount * 4);

            Console.WriteLine($"{totalSum} lv.");

        }
    }
}
