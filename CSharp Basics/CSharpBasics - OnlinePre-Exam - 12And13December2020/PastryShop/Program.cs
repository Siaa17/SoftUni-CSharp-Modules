using System;

namespace PastryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string pastry = Console.ReadLine();
            int orderedPastryCount = int.Parse(Console.ReadLine());
            int dayOfDecBeforeXmas = int.Parse(Console.ReadLine());

            double price = 0;

            if (dayOfDecBeforeXmas <= 15)
            {
                switch (pastry)
                {
                    case "Cake":
                        price = 24;
                        break;
                    case "Souffle":
                        price = 6.66;
                        break;
                    case "Baklava":
                        price = 12.60;
                        break;
                }
            }
            else if (dayOfDecBeforeXmas > 15)
            {
                switch (pastry)
                {
                    case "Cake":
                        price = 28.70;
                        break;
                    case "Souffle":
                        price = 9.80;
                        break;
                    case "Baklava":
                        price = 16.98;
                        break;
                }
            }

            double totalPrice = orderedPastryCount * price;

            if (dayOfDecBeforeXmas <= 22)
            {
                if (totalPrice >= 100 && totalPrice <= 200)
                {
                    totalPrice *= 0.85;
                }
                else if (totalPrice > 200)
                {
                    totalPrice *= 0.75;
                }

                if (dayOfDecBeforeXmas <= 15)
                {
                    totalPrice *= 0.90;
                }
            }

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
