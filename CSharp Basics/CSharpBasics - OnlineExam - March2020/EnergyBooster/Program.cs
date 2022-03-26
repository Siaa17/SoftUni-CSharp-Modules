using System;

namespace EnergyBooster3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string setSize = Console.ReadLine();
            int orderedSetsCount = int.Parse(Console.ReadLine());

            double fruitPrice = 0;

            switch (fruit)
            {
                case "Watermelon":
                    if (setSize == "small")
                    {
                        fruitPrice = 2 * 56.00;
                    }
                    else if (setSize == "big")
                    {
                        fruitPrice = 5 * 28.70;
                    }
                    break;
                case "Mango":
                    if (setSize == "small")
                    {
                        fruitPrice = 2 * 36.66;
                    }
                    else if (setSize == "big")
                    {
                        fruitPrice = 5 * 19.60;
                    }
                    break;
                case "Pineapple":
                    if (setSize == "small")
                    {
                        fruitPrice = 2 * 42.10;
                    }
                    else if (setSize == "big")
                    {
                        fruitPrice = 5 * 24.80;
                    }
                    break;
                case "Raspberry":
                    if (setSize == "small")
                    {
                        fruitPrice =2 * 20.00;
                    }
                    else if (setSize == "big")
                    {
                        fruitPrice = 5 * 15.20;
                    }
                    break;
            }

            double totalPrice = orderedSetsCount * fruitPrice;

            if (totalPrice >= 400 && totalPrice <= 1000)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (totalPrice > 1000)
            {
                totalPrice -= totalPrice * 0.5;
            }

            Console.WriteLine($"{totalPrice:F2} lv.");
        }
    }
}
