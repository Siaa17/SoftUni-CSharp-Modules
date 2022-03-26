using System;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
              .Append($" {this.Model}:")
              .AppendLine()
              .AppendLine($"    Power: {this.Power}")
              .AppendLine(this.Displacement.HasValue ? $"    Displacement: {this.Displacement}" : "    Displacement: n/a")
              .AppendLine(String.IsNullOrEmpty(this.Efficiency) ? "    Efficiency: n/a" : $"    Efficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
