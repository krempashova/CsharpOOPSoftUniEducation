using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models;
public class Robots : IIndentifable
{
    public Robots(string model, string id)
    {
        Model = model;
        Id = id;
    }
    public string Model { get; private set; }
    public string Id { get; private set; }


}

