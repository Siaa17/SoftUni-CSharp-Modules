using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => pets.Count;

        public void Add(Pet pet)
        {
            if (this.Capacity > this.Count)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(p => p.Name == name);

            if (pet == null)
            {
                return false;
            }

            pets.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner) => pets.FirstOrDefault(p => p.Name == name && p.Owner == owner);

        public Pet GetOldestPet() => pets.OrderByDescending(p => p.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");

            foreach (Pet pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
