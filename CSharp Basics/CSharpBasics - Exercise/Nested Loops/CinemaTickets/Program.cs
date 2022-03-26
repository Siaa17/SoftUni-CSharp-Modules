using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();

            int kidTicketsCount = 0;
            int studentTicketsCount = 0;
            int standardTicketsCount = 0;

            while (movie != "Finish")
            {
                int seatsAvaliable = int.Parse(Console.ReadLine());
                
                string ticketType = Console.ReadLine();

                int ticketsCounter = 0;

                while (ticketType != "End")
                {
                    ticketsCounter++;

                    switch (ticketType)
                    {
                        case "kid":
                            kidTicketsCount++;
                            break;
                        case "student":
                            studentTicketsCount++;
                            break;
                        case "standard":
                            standardTicketsCount++;
                            break;
                    }

                    if (ticketsCounter == seatsAvaliable)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();
                }

                double seatsTaken = 1.0 * ticketsCounter / seatsAvaliable * 100;
                Console.WriteLine($"{movie} - {seatsTaken:F2}% full.");

                movie = Console.ReadLine();
            }

            int totalTickets = kidTicketsCount + studentTicketsCount + standardTicketsCount;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{1.0 * studentTicketsCount / totalTickets * 100:F2}% student tickets.");
            Console.WriteLine($"{1.0 * standardTicketsCount / totalTickets * 100:F2}% standard tickets.");
            Console.WriteLine($"{1.0 * kidTicketsCount / totalTickets * 100:F2}% kids tickets.");
        }
    }
}
