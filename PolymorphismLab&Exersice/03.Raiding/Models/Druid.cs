namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int constPower = 80;
        public Druid(string name) 
            : base(name, constPower)
        {

        }
        public override string CastAbility()
        => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
