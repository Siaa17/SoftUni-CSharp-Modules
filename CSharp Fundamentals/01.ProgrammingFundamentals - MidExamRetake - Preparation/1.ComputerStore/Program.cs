using System;

namespace _1.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double totalPriceWithoutTaxes = 0;
            double totalTaxes = 0;
            double finalPriceWithTaxes = 0;

            while (command != "regular" && command != "special")
            {
                double priceWithoutTax = double.Parse(command);

                if (priceWithoutTax < 0)
                {
                    Console.WriteLine("Invalid price!");

                    command = Console.ReadLine();

                    continue;
                }
                else
                {
                    totalPriceWithoutTaxes += priceWithoutTax;

                    totalTaxes = 0.2 * totalPriceWithoutTaxes;

                    finalPriceWithTaxes = totalPriceWithoutTaxes + totalTaxes;
                }

                command = Console.ReadLine();
            }

            if (finalPriceWithTaxes == 0)
            {
                Console.WriteLine("Invalid order!");

                return;
            }
            else if (command == "special")
            {
                double finalPriceWithDiscount = finalPriceWithTaxes - finalPriceWithTaxes * 0.1;

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:F2}$");
                Console.WriteLine($"Taxes: {totalTaxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {finalPriceWithDiscount:F2}$");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:F2}$");
                Console.WriteLine($"Taxes: {totalTaxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {finalPriceWithTaxes:F2}$");
            }
        }
    }
}
