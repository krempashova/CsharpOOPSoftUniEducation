namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer:INamemable
    {

        public int Food { get;}
        void BuyFood();
    }
}
