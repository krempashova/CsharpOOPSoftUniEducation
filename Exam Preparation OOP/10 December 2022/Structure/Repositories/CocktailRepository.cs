using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        public CocktailRepository()
        {
            this.availablecocteils = new List<ICocktail>();
        }
        private readonly List<ICocktail> availablecocteils;
        public IReadOnlyCollection<ICocktail> Models => this.availablecocteils;

        public void AddModel(ICocktail model)
        {
            this.availablecocteils.Add(model);
        }
    }
}
