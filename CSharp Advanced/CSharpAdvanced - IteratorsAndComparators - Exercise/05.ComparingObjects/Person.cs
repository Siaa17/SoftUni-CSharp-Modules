using System;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name 
        {
            get => this.name;
            set => this.name = value;
        } 

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public string Town 
        {
            get => this.town;
            set => this.town = value;
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                result = Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
