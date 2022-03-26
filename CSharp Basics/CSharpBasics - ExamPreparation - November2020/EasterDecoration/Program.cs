using System;

namespace EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfClients = int.Parse(Console.ReadLine());

            double totalBill = 0;

            for (int i = 0; i < numOfClients; i++)
            {
                string purchase = Console.ReadLine();
                
                double currentBill = 0;
                int countOfItems = 0;

                while (purchase != "Finish")
                {
                    countOfItems++;
                    switch (purchase)
                    {
                        case "basket":                           
                            currentBill += 1.50;
                            break;
                        case "wreath":                         
                            currentBill += 3.80;                           
                            break;
                        case "chocolate bunny":
                            currentBill += 7;
                            break;
                    }

                    purchase = Console.ReadLine();
                }

                if (countOfItems % 2 ==0)
                {
                    currentBill -= currentBill * 0.2;
                }

                totalBill += currentBill;

                Console.WriteLine($"You purchased {countOfItems} items for {currentBill:F2} leva.");
            }

            double averagePrice = totalBill / numOfClients;
            Console.WriteLine($"Average bill per client is: {averagePrice:F2} leva.");
        }
    }
}
