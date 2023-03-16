namespace WildFarm.Factories.Interfaces
{
    using Models.Interfaces;
    public interface IAnimalFactory
    {
        IAnimal CreatedNewAnimal(string[]animalinfo);
    }
}
