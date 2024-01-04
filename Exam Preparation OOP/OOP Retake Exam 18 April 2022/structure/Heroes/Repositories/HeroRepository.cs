using Heroes.Models.Contracts;
using Heroes.Models.Heros;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        private List<IHero> heroes;
        public IReadOnlyCollection<IHero> Models => this.heroes;

        public void Add(IHero model)
        {
            heroes.Add(model);
        }

        public IHero FindByName(string name)
        => heroes.FirstOrDefault(g => g.Name == name);

        public bool Remove(IHero model)
       => heroes.Remove(model);
    }
}
