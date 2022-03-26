using System;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
              .Append($"{this.Model}:")
              .AppendLine()
              .AppendLine($" {this.Engine}")
              .AppendLine(this.Weight.HasValue ? $"  Weight: {this.Weight}" : "  Weight: n/a")
              .AppendLine(String.IsNullOrEmpty(this.Color) ? "  Color: n/a" : $"  Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
