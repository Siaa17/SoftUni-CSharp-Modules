namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;

        public Warrior(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
