using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double pricePerFlower = 0;

            switch (typeFlower)
            {
                case "Roses":
                    pricePerFlower = 5;
                    break;
                case "Dahlias":
                    pricePerFlower = 3.80;
                    break;
                case "Tulips":
                    pricePerFlower = 2.80;
                    break;
                case "Narcissus":
                    pricePerFlower = 3;
                    break;
                case "Gladiolus":
                    pricePerFlower = 2.50;
                    break;
            }

            double totalPrice = countFlowers * pricePerFlower;

            if (countFlowers > 80 && typeFlower == "Roses")
            {
                totalPrice -= 0.10 * totalPrice;
            }
            else if (countFlowers > 90 && typeFlower == "Dahlias")
            {
                totalPrice -= 0.15 * totalPrice;
            }
            else if (countFlowers > 80 && typeFlower == "Tulips")
            {
                totalPrice -= 0.15 * totalPrice;
            }
            else if (countFlowers < 120 && typeFlower == "Narcissus")
            {
                totalPrice += 0.15 * totalPrice;
            }
            else if (countFlowers < 80 && typeFlower == "Gladiolus")
            {
                totalPrice += 0.20 * totalPrice;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {typeFlower}" +
                    $" and {budget - totalPrice:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:F2} leva more.");
            }
        }
    }
}
