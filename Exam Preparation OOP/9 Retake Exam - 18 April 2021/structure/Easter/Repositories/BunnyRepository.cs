using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;
        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => this.models.AsReadOnly();

        public void Add(IBunny model)
        {
            this.models.Add(model);
        }

        public IBunny FindByName(string name)
      => this.models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IBunny model)
       => this.models.Remove(model);
    }
}
