using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < countOfOrders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                byte days = byte.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double priceOfCoffee = ((days * capsulesCount) * pricePerCapsule);

                Console.WriteLine($"The price for the coffee is: ${priceOfCoffee:F2}");

                sum += priceOfCoffee;
            }

            Console.WriteLine($"Total: ${sum:F2}");
        }
    }
}
