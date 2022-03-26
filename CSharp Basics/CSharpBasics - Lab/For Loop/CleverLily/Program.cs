using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            int toyCounter = 0;
            double savedMoney = 0;
            double moneyPresent = 10;
           
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += moneyPresent;
                    savedMoney--;
                    moneyPresent += 10;
                }
                else
                {
                    toyCounter++;
                }
            }

            double moneyForToys = toyCounter * toyPrice;
            savedMoney += moneyForToys;

            if (savedMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {savedMoney - washingMachinePrice:F2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - savedMoney:F2}");
            }
        }
    }
}
