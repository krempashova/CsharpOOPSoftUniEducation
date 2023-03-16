namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int constPower = 100;
        public Warrior(string name) 
            : base(name, constPower)
        {
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
