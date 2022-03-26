using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Catalogue> vehicles = new List<Catalogue>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] dataVehicle = input
                    .Split('/', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = dataVehicle[0];
                string brand = dataVehicle[1];
                string model = dataVehicle[2];
                string horsePower = dataVehicle[3];
                string weight = dataVehicle[3];

                Catalogue vehicle = new Catalogue();

                vehicle.Type = type;
                vehicle.Brand = brand;
                vehicle.Model = model;
                vehicle.HorsePower = horsePower;
                vehicle.Weight = weight;

                vehicles.Add(vehicle);
            }

            List<Catalogue> sortedVehicles = vehicles
                .OrderBy(v => v.Brand)
                .ToList();

            int counter = 1;

            foreach (Catalogue vehicle in sortedVehicles)
            {
                if (vehicle.Type == "Car")
                {
                    if (counter == 1)
                    {
                        Console.WriteLine("Cars:");
                        counter++;
                    }
                    
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.HorsePower}hp");
                }
            }

            int counter2 = 1;

            foreach (Catalogue vehicle in sortedVehicles)
            {
                if (vehicle.Type == "Truck")
                {
                    if (counter2 == 1)
                    {
                        Console.WriteLine("Trucks:");
                        counter2++;
                    }

                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.Weight}kg");
                }
            }
        }
    }

    class Catalogue
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
        public string Weight { get; set; }
    }
}
