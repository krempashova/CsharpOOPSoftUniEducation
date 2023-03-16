using System.Net.Http.Headers;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
 
        public IFood CreatedFood(string type, int quantity)
        {
            IFood food;
            switch (type)
            {
                case "Fruit":
                    food = new Fruit(quantity); break;
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
                default:throw new ArgumentException();
                    break;
            }
            return food;
        }
    }
}
