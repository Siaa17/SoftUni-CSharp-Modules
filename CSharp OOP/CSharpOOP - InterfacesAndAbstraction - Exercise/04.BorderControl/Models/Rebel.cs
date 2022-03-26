using _04.BorderControl.Interfaces;

namespace _04.BorderControl.Models
{
    public class Rebel : IRebel
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get ; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
