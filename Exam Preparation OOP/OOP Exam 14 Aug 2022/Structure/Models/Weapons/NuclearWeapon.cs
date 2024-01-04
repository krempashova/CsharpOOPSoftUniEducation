namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double nuclearWeapon = 15;
        public NuclearWeapon(int destructionLevel) 
            : base(destructionLevel, nuclearWeapon)
        {
        }
    }
}
