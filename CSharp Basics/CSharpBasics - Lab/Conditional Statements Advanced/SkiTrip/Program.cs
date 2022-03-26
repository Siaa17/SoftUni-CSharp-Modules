using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysToStay = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string evaluation = Console.ReadLine();

            double pricePerNight = 0;
            double discount = 0;

            switch (typeOfRoom)
            {
                case "room for one person":
                    pricePerNight = 18;
                    break;
                case "apartment":
                    pricePerNight = 25;
                   
                    if (daysToStay < 10)
                    {
                        discount = 0.30;
                    }
                    else if (daysToStay >= 10 && daysToStay <= 15)
                    {
                        discount = 0.35;
                    }
                    else
                    {
                        discount = 0.50;
                    }
                    break;
                case "president apartment":
                    pricePerNight = 35;
                    
                    if (daysToStay < 10)
                    {
                        discount = 0.10;
                    }
                    else if (daysToStay >= 10 && daysToStay <= 15)
                    {
                        discount = 0.15;
                    }
                    else
                    {
                        discount = 0.20;
                    }
                    break;
            }

            double totalPrice = (daysToStay - 1) * pricePerNight;
            totalPrice -= totalPrice * discount;

            if (evaluation == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.10;
            }

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
