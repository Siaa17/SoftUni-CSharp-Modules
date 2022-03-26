using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mileageByCar = new Dictionary<string, int>();
            Dictionary<string, int> fuelByCar = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carName = carData[0];
                int mileage = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);

                mileageByCar.Add(carName, mileage);
                fuelByCar.Add(carName, fuel);
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Stop")
            {
                string[] lineParts = line
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = lineParts[0];
                string carName = lineParts[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(lineParts[2]);
                    int fuel = int.Parse(lineParts[3]);

                    if (fuel > fuelByCar[carName])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        mileageByCar[carName] += distance;
                        fuelByCar[carName] -= fuel;

                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (mileageByCar[carName] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");

                        mileageByCar.Remove(carName);
                        fuelByCar.Remove(carName);
                    }
                }
                else if (command == "Refuel")
                {
                    int fuelToAdd = int.Parse(lineParts[2]);

                    if (fuelToAdd + fuelByCar[carName] > 75)
                    {
                        fuelToAdd = 75 - fuelByCar[carName];
                    }

                    fuelByCar[carName] += fuelToAdd;

                    Console.WriteLine($"{carName} refueled with {fuelToAdd} liters");
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(lineParts[2]);

                    mileageByCar[carName] -= kilometers;

                    if (mileageByCar[carName] < 10000)
                    {
                        mileageByCar[carName] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            Dictionary<string, int> sorted = mileageByCar
                .OrderByDescending(c => c.Value)
                .ThenBy(c => c.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                string carName = kvp.Key;
                int mileage = kvp.Value;
                int fuel = fuelByCar[carName];

                Console.WriteLine($"{carName} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }
        }
    }
}
