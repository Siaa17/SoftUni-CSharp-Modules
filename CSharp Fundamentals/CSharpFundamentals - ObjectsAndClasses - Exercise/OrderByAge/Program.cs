using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string line = String.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] personData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personData[0];
                string identityDocument = personData[1];
                int age = int.Parse(personData[2]);

                Person person = new Person();

                person.Name = name;
                person.ID = identityDocument;
                person.Age = age;

                people.Add(person);
            }

            List<Person> sortedPeople = people
                .OrderBy(p => p.Age)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, sortedPeople));
        }
    }

    class Person
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
