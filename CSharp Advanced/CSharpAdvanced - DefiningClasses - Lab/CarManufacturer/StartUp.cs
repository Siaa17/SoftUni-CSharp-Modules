using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Car car = new Car();

            //car.Make = "Nissan";
            //car.Model = "Rogue";
            //car.Year = 2020;
            //car.FuelQuantity = 350;
            //car.FuelConsumption = 10;
            //car.Drive(20);

            //Console.WriteLine(car.WhoAmI());

            //Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //Tire[] tires = new Tire[]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //};

            //Engine engine = new Engine(560, 6300);

            //Car car = new Car("Nissan", "Rogue", 2020, 280, 12, engine, tires);

            List<Tire[]> listOfTires = new List<Tire[]>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Tire[] tires = new Tire[]
                {
                    new Tire(int.Parse(tireInfo[0]), double.Parse(tireInfo[1])),
                    new Tire(int.Parse(tireInfo[2]), double.Parse(tireInfo[3])),
                    new Tire(int.Parse(tireInfo[4]), double.Parse(tireInfo[5])),
                    new Tire(int.Parse(tireInfo[6]), double.Parse(tireInfo[7]))
                };

                listOfTires.Add(tires);
            }

            List<Engine> listOfEngines = new List<Engine>();

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                listOfEngines.Add(engine);
            }

            List<Car> specialCars = new List<Car>();

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                if (engineIndex >= 0 && engineIndex < listOfEngines.Count
                    && tiresIndex >= 0 && tiresIndex < listOfTires.Count)
                {
                    Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, listOfEngines[engineIndex], listOfTires[tiresIndex]);

                    specialCars.Add(car);
                }
            }

            specialCars = specialCars.Where(x => x.Year >= 2017 
            && x.Engine.HorsePower > 330 
            && x.Tires.Sum(y => y.Pressure) >= 9 
            && x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            if (specialCars.Count > 0)
            {
                foreach (Car car in specialCars)
                {
                    car.Drive(20);

                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
