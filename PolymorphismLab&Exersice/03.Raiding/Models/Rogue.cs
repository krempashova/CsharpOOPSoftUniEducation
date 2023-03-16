namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int constPower = 80;
        public Rogue(string name) 
            : base(name, constPower)
        {

        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
