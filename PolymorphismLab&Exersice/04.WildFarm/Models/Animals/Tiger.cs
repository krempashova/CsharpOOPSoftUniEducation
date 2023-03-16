namespace WildFarm.Models.Animals
{
    using Foods;
    public class Tiger : Feline
    {
        private const double TigerMultiplier = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            
            : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods =>

            new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => TigerMultiplier;

        public override string CreateSound()
      => "ROAR!!!";
    }
}
