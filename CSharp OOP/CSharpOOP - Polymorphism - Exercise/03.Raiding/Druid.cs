namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80;

        public Druid(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
