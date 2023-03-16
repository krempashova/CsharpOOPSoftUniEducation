namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int constPower = 100;
        public Paladin(string name) 
            : base(name, constPower)
        {
        }
        public override string CastAbility()
        => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
