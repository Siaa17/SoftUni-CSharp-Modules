using System;
using System.Linq;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Bus bus = (Bus)CreateVehicle();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = currentLine[0];
                string vehicleType = currentLine[1];
                double parameter = double.Parse(currentLine[2]);

                if (command == "Drive")
                {
                    if (vehicleType == nameof(Car))
                    {
                        CanDrive(car, parameter);
                    }
                    else if (vehicleType == nameof(Truck))
                    {
                        CanDrive(truck, parameter);
                    }
                    else if (vehicleType == nameof(Bus))
                    {
                        bus.IsEmpty = false;
                        CanDrive(bus, parameter);
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Refuel(parameter);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Refuel(parameter);
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Refuel(parameter);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    bus.IsEmpty = true;
                    CanDrive(bus, parameter);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string vehicleType = vehicle.GetType().Name;

            string result = canDrive
                ? $"{vehicleType} travelled {distance} km"
                : $"{vehicleType} needs refueling";

            Console.WriteLine(result);
        }

        private static Vehicle CreateVehicle()
        {
            string[] vehicleInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string type = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
