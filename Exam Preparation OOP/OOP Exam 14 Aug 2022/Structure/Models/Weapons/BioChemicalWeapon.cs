using System.Runtime.ConstrainedExecution;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double biochemicalPrice = 3.2;
        public BioChemicalWeapon(int destructionLevel) 
            : base(destructionLevel, biochemicalPrice)
        {
        }
    }
}
