using Raiding.Models.Interfaces;

namespace Raiding.Factoris.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero CreatedHeros(string name, string type);
    }
}
