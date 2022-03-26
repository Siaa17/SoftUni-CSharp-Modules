using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double pricePerPerson = 0;
            double discount = 0;

            if (groupType == "Students")
            {
                if (peopleCount >= 30)
                {
                    discount = 0.15;
                }

                if (day == "Friday")
                {
                    pricePerPerson = 8.45;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 9.8;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 10.46;
                }
            }
            else if (groupType == "Business")
            {
                if (peopleCount >= 100)
                {
                    peopleCount -= 10;
                }

                if (day == "Friday")
                {
                    pricePerPerson = 10.9;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 15.6;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 16;
                }
            }
            else if (groupType == "Regular")
            {
                if (peopleCount >= 10 && peopleCount <= 20)
                {
                    discount = 0.05;
                }

                if (day == "Friday")
                {
                    pricePerPerson = 15;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 20;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 22.5;
                }
            }

            double totalPrice = peopleCount * pricePerPerson;

            if (discount != 0)
            {
                totalPrice -= totalPrice * discount;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
