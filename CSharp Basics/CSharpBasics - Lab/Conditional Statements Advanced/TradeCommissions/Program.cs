using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double volumeSales = double.Parse(Console.ReadLine());

            double commissions = 0;

            switch (city)
            {
                case "Sofia":
                    if (volumeSales >= 0 && volumeSales <= 500)
                    {
                        commissions = 0.05 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 500 && volumeSales <= 1000)
                    {
                        commissions = 0.07 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 1000 && volumeSales <= 10000)
                    {
                        commissions = 0.08 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 10000)
                    {
                        commissions = 0.12 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Varna":
                    if (volumeSales >= 0 && volumeSales <= 500)
                    {
                        commissions = 0.045 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 500 && volumeSales <= 1000)
                    {
                        commissions = 0.075 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 1000 && volumeSales <= 10000)
                    {
                        commissions = 0.10 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 10000)
                    {
                        commissions = 0.13 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Plovdiv":
                    if (volumeSales >= 0 && volumeSales <= 500)
                    {
                        commissions = 0.055 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 500 && volumeSales <= 1000)
                    {
                        commissions = 0.08 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 1000 && volumeSales <= 10000)
                    {
                        commissions = 0.12 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else if (volumeSales > 10000)
                    {
                        commissions = 0.145 * volumeSales;
                        Console.WriteLine($"{commissions:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
