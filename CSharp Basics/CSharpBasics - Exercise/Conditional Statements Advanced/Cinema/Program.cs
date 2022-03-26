using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double income = 0;
           
            switch (projectionType)
            {
                case "Premiere":
                    income = rows * columns * 12.00;
                    break;
                case "Normal":
                    income = rows * columns * 7.50;
                    break;
                case "Discount":
                    income = rows * columns * 5.00;
                    break;
            }

            Console.WriteLine($"{income:F2} leva");
        }
    }
}
