namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitialEnergy = 50;

        public SleepyBunny(string name)
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 5;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }

            base.Work();
        }
    }
}
