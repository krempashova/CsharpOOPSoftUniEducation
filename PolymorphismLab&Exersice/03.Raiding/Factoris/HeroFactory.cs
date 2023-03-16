namespace Raiding.Factoris
{
    using Interfaces;
    using Raiding.Models;
    using Raiding.Models.Interfaces;

    public class HeroFactory : IHeroFactory
    {
        public IBaseHero CreatedHeros(string name, string type)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Warrior":
                    return new Warrior(name);
                case "Rogue":
                    return new Rogue(name);
                default:
                   throw new ArgumentException("Invalid hero!");
                  
            }
        }
    }
}
