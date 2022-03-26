using System;
using System.Collections.Generic;
using System.Linq;
using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ICitizen> buyers = new List<ICitizen>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] inputParts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputParts.Length == 4)
                {
                    string name = inputParts[0];
                    int age = int.Parse(inputParts[1]);
                    string id = inputParts[2];
                    string birthdate = inputParts[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else if (inputParts.Length == 3)
                {
                    string name = inputParts[0];
                    int age = int.Parse(inputParts[1]);
                    string group = inputParts[2];

                    Rebel rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                if (!buyers.Any(b => b.Name == line))
                {
                    continue;
                }

                buyers.Where(b => b.Name == line).FirstOrDefault().BuyFood();
            }

            int totalAmountOfFood = buyers.Sum(b => b.Food);

            Console.WriteLine(totalAmountOfFood);
        }
    }
}
