using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Person firstPerson = new Person()
            //{
            //    Name = "Pesho",
            //    Age = 20
            //};

            //Person secondPerson = new Person()
            //{
            //    Name = "Gosho",
            //    Age = 18
            //};

            //Person thirdPerson = new Person()
            //{
            //    Name = "Stamat",
            //    Age = 43
            //};

            //Console.WriteLine(firstPerson.ToString());
            //Console.WriteLine(secondPerson.ToString());
            //Console.WriteLine(thirdPerson.ToString());


            //Person noName = new Person();
            //Console.WriteLine($"No name guy: {noName.Name} - {noName.Age} yr old");
            //Person someone = new Person(28);
            //Console.WriteLine($"Someone's age: {someone.Name} - {someone.Age} yrs old");
            //Person biana = new Person("Biana", 25);
            //Console.WriteLine($"Biana's info: {biana.Name} - {biana.Age} yrs old");


            //Family family = new Family();

            //int n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < n; i++)
            //{
            //    string[] memberInfo = Console.ReadLine()
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //        .ToArray();

            //    string name = memberInfo[0];
            //    int age = int.Parse(memberInfo[1]);

            //    Person person = new Person(name, age);

            //    family.AddMembers(person);
            //}

            //Console.WriteLine(family.GetOldestMember());


            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            people = people.OrderBy(p => p.Name).Where(p => p.Age > 30).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
