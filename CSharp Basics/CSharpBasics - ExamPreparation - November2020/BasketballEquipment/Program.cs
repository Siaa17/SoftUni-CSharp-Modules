using System;

namespace BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int annualFee = int.Parse(Console.ReadLine());

            double trainers = annualFee * 0.6;
            double equipment = trainers * 0.8;
            double ball = equipment / 4;
            double accessories = ball / 5;

            double totalPrice = annualFee + trainers + equipment + ball + accessories;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
