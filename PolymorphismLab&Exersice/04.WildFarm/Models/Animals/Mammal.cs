namespace WildFarm.Models.Animals
{
    using Interfaces;
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight,string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;

        }

        public string LivingRegion { get; private set; }
    }
}
