namespace WildFarm.Models.Animals
{
    using Interfaces;
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
            
        {
            Name = name;
            Weight = weight;
           
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        

        protected abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        public abstract string CreateSound();
        public void Eat(IFood food)
        {
            if(!this.PreferredFoods.Any(dt=>food.GetType().Name==dt.Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            this.Weight += food.Quantity * WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
