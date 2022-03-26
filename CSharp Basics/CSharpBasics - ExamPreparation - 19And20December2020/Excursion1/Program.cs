using System;

namespace Excursion1
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleInGroup = int.Parse(Console.ReadLine());
            int overnights = int.Parse(Console.ReadLine());
            double transportCards = double.Parse(Console.ReadLine());
            int museumTickets = int.Parse(Console.ReadLine());

            int overnightPrice = 20;
            double transportCardPrice = 1.60;
            int museumTicketPrice = 6;

            overnights *= overnightPrice;
            transportCards *= transportCardPrice;
            museumTickets *= museumTicketPrice;

            double totalPricePerPerson = overnights + transportCards + museumTickets;
            double totalPriceForWholeGroup = totalPricePerPerson * peopleInGroup;
            totalPriceForWholeGroup += totalPriceForWholeGroup * 0.25;

            Console.WriteLine($"{totalPriceForWholeGroup:F2}");
        }
    }
}
