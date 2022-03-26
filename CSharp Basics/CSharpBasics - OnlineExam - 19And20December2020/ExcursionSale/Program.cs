using System;

namespace ExcursionSale
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfSeaExcursions = int.Parse(Console.ReadLine());
            int numOfMountainExcursions = int.Parse(Console.ReadLine());

            int packageSeaPrice = 680;
            int packageMountainPrice = 499;
            int profit = 0;
            bool isManaged = false;

            string packageName = Console.ReadLine();

            while (packageName != "Stop")
            {
                if (packageName == "sea")
                {
                    if (numOfSeaExcursions > 0)
                    {
                        profit += packageSeaPrice;
                        numOfSeaExcursions--;
                    }
                }
                else if (packageName == "mountain")
                {
                    if (numOfMountainExcursions > 0)
                    {
                        profit += packageMountainPrice;
                        numOfMountainExcursions--;
                    }
                }

                    packageName = Console.ReadLine();

                if (numOfSeaExcursions == 0 && numOfMountainExcursions == 0)
                {
                    isManaged = true;
                    break;
                }
            }

            if (isManaged)
            {
                Console.WriteLine($"Good job! Everything is sold.");
            }

            Console.WriteLine($"Profit: {profit} leva.");
        }
    }
}
