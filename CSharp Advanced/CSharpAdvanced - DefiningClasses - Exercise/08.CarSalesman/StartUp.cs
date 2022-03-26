using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Engine> engines = new HashSet<Engine>();

            List<Car> cars = new List<Car>();

            int countOfEngines = int.Parse(Console.ReadLine());

            FillEngines(engines, countOfEngines);

            int countOfCars = int.Parse(Console.ReadLine());

            FillCars(engines, cars, countOfCars);

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }           
        }

        public static List<Car> FillCars(HashSet<Engine> engines, List<Car> cars, int countOfCars)
        {
            for (int i = 0; i < countOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carInfo[0];
                Engine engine = engines.First(e => e.Model == carInfo[1]);

                Car car = null;

                if (carInfo.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carInfo.Length == 3)
                {
                    bool isWeight = int.TryParse(carInfo[2], out int weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carInfo[2]);
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];

                    car = new Car(model, engine, weight, color);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }

            return cars;
        }

        public static HashSet<Engine> FillEngines(HashSet<Engine> engines, int countOfEngines)
        {
            for (int i = 0; i < countOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine engine = null;

                if (engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (engineInfo.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineInfo[2], out int displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineInfo[2]);
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }

                if (engine != null)
                {
                    engines.Add(engine);
                }
            }

            return engines;
        }
    }
}
