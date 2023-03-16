namespace WildFarm.Factories
{
    using Interfaces;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Interfaces;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreatedNewAnimal(string[] animalinfo)
        {
            string type = animalinfo[0];
            string name = animalinfo[1];
            double weight = double.Parse(animalinfo[2]);
            string thirdArg = animalinfo[3];
           
            IAnimal animal;

            switch (type)
            {
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(thirdArg));
                    break;
                        
                case "Hen":
                    animal = new Hen(name, weight, double.Parse(thirdArg));
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, thirdArg);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, thirdArg);
                    break;
                case "Cat":
                    string lastArg = animalinfo[4];
                    animal = new Cat(name, weight, thirdArg, lastArg);
                    break;
                case "Tiger":
                   lastArg = animalinfo[4];
                    animal = new Tiger(name, weight, thirdArg, lastArg);
                    break;

                default: throw new ArgumentException();
                    break;
                    
            }
            return animal;
        }
    }
}
