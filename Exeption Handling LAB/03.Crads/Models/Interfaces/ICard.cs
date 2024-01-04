namespace Cards.Models.Interfaces
{
    public  interface ICard
    { 
       string Face { get; }
        string Suit { get; }

        string ToString();
    }
}
