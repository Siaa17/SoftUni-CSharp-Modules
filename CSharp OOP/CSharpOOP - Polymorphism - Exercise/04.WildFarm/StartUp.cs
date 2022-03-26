using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] animalInfo = line.Split(" ");
                Animal animal = CreateAnimal(animalInfo);
                animals.Add(animal);

                string[] foodInfo = Console.ReadLine().Split(" ");
                Food food = CreateFood(foodInfo);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodInfo)
        {
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            Food food = null;

            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }

            return food;
        }

        private static Animal CreateAnimal(string[] animalInfo)
        {
            string animalType = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            Animal animal = null;

            switch (animalType)
            {
                case "Owl":
                    double wingSizeOwl = double.Parse(animalInfo[3]);
                    animal = new Owl(name, weight, wingSizeOwl);
                    break;
                case "Hen":
                    double wingSizeHen = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSizeHen);
                    break;
                case "Mouse":
                    string livingRegionMouse = animalInfo[3];
                    animal = new Mouse(name, weight, livingRegionMouse);
                    break;
                case "Dog":
                    string livingRegionDog = animalInfo[3];
                    animal = new Dog(name, weight, livingRegionDog);
                    break;
                case "Cat":
                    string livingRegionCat = animalInfo[3];
                    string breedCat = animalInfo[4];
                    animal = new Cat(name, weight, livingRegionCat, breedCat);
                    break;
                case "Tiger":
                    string livingRegionTiger = animalInfo[3];
                    string breedTiger = animalInfo[4];
                    animal = new Tiger(name, weight, livingRegionTiger, breedTiger);
                    break;
            }

            return animal;
        }
    }
}
