namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;

        public Rogue(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
