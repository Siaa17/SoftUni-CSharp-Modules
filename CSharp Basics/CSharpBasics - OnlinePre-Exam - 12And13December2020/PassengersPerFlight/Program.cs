using System;

namespace PassengersPerFlight
{
    class Program
    {
        static void Main(string[] args)
        {
            int airlinesCount = int.Parse(Console.ReadLine());

            double maxAverageCountPass = 0;
            string airlineWithMaxPass = "";

            for (int i = 0; i < airlinesCount; i++)
            {
                string airlineName = Console.ReadLine();

                int flights = 0;
                int totalPassengers = 0;

                string command = Console.ReadLine();

                while (command != "Finish")
                {
                    int passengersPerFlight = int.Parse(command);

                    flights++;
                    totalPassengers += passengersPerFlight;

                    command = Console.ReadLine();
                }

                double averagePassCount = totalPassengers / flights;

                Console.WriteLine($"{airlineName}: {Math.Floor(averagePassCount)} passengers.");

                if (averagePassCount > maxAverageCountPass)
                {
                    maxAverageCountPass = averagePassCount;
                    airlineWithMaxPass = airlineName;
                }
            }

            Console.WriteLine($"{airlineWithMaxPass} has most passengers per flight: {maxAverageCountPass}");
        }
    }
}
