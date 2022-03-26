using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double balance = 0;

            while (command != "Start")
            {
                double currentCoin = double.Parse(command);

                if (currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 ||
                    currentCoin == 1 || currentCoin == 2)
                {
                    balance += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }
   
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                double productPrice = 0;

                if (command == "Nuts")
                {
                    productPrice = 2;
                }
                else if (command == "Water")
                {
                    productPrice = 0.7;
                }
                else if (command == "Crisps")
                {
                    productPrice = 1.5;
                }
                else if (command == "Soda")
                {
                    productPrice = 0.8;
                }
                else if (command == "Coke")
                {
                    productPrice = 1;
                }

                if (productPrice != 0)
                {
                    if (balance >= productPrice)
                    {
                        Console.WriteLine($"Purchased {command.ToLower()}");
                        balance -= productPrice;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine($"Change: {balance:F2}");
        }
    }
}
