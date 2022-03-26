namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(int battery, string model, string color)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; set; }

        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
        }
    }
}
