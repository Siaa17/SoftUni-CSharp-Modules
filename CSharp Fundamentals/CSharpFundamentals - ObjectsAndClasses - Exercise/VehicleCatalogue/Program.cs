using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string line = String.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] vehicleData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = vehicleData[0];
                string model = vehicleData[1];
                string color = vehicleData[2];
                int horsePower = int.Parse(vehicleData[3]);

                Vehicle vehicle = new Vehicle();

                vehicle.Type = type;
                vehicle.Model = model;
                vehicle.Color = color;
                vehicle.HorsePower = horsePower;

                vehicles.Add(vehicle);
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle vehicle = GetVehicleByModel(vehicles, input);

                if (vehicle == null)
                {
                    continue;
                }

                if (vehicle.Type == "car")
                {
                    Console.WriteLine("Type: Car");
                }
                else
                {
                    Console.WriteLine("Type: Truck");
                }
                
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
            }

            double carsHorsePowerAvg = CalcAvgHorsePowerByType(vehicles, "car");   
            double trucksHorsePowerAvg = CalcAvgHorsePowerByType(vehicles, "truck");

            Console.WriteLine($"Cars have average horsepower of: {carsHorsePowerAvg:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksHorsePowerAvg:F2}.");
        }

        static Vehicle GetVehicleByModel(List<Vehicle> vehicles, string model)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Model == model)
                {
                    return vehicle;
                }
            }

            return null;
        }

        static double CalcAvgHorsePowerByType(List<Vehicle> vehicles, string type)
        {
            int typeCount = 0;
            int typeHorsePowerTotal = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Type == type)
                {
                    typeCount++;
                    typeHorsePowerTotal += vehicle.HorsePower;
                }
            }

            if (typeCount == 0)
            {
                return 0;
            }

            return typeHorsePowerTotal * 1.0 / typeCount;
        }
    }

    class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }
    }
}
