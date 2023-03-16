using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;
using System;
namespace WildFarm.Core
{
    

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;
        private Engine()
        {
            this.animals = new HashSet<IAnimal>();
        }
        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
            :this()

        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
           
        }

        public void Run()
        {
            string command;
            while ((command=this.reader.ReadLine())!="End")
            {


                this.HandleInput(command);

            }
            foreach (IAnimal animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
        private IAnimal BuildAnimalUsingFactory(string command)
        {

            string[] animalinfo = command
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            IAnimal currAnimal = this.animalFactory.CreatedNewAnimal(animalinfo);
            return currAnimal;
        }
        private IFood BuildFoodUsingFactory()
        {
            string[] foodinfo = this.reader.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = foodinfo[0];
            int quantity = int.Parse(foodinfo[1]);
            IFood currFood = this.foodFactory.CreatedFood(type, quantity);
            return currFood;
        }
        private void HandleInput(string command)
        {
            IAnimal currAnimal = null;
            try
            {
                currAnimal = this.BuildAnimalUsingFactory(command);
                IFood currFood = this.BuildFoodUsingFactory();

                this.writer.WriteLine(currAnimal.CreateSound());
                currAnimal.Eat(currFood);
            }
            catch (ArgumentException ex)
            {
                this.writer.WriteLine(ex.Message);
            }
            
            
            catch (Exception)
            {
                throw;
            }

            this.animals.Add(currAnimal);
        }
        
       
    }
}

