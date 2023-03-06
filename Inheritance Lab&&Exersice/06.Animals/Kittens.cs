namespace Animals
{
    public class Kittens : Cat
    {
        private const string KittensGender = "Female";
        public Kittens(string name, int age) : base(name, age, KittensGender)
        {
        }
        public override string ProduceSound() => "Meow";


    }
}
