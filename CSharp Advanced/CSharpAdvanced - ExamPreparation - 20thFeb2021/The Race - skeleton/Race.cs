using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.racers.Count;

        public void Add(Racer racer)
        {
            if (this.Capacity > this.Count)
            {
                this.racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (this.racers.Any(r => r.Name == name))
            {
                this.racers.Remove(this.racers.FirstOrDefault(r => r.Name == name));
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer() => this.racers.OrderByDescending(r => r.Age).FirstOrDefault();

        public Racer GetRacer(string name) => this.racers.FirstOrDefault(r => r.Name == name);

        public Racer GetFastestRacer() => this.racers.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (Racer racer in this.racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
