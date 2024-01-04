using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models;
        public EggRepository()
        {
            this.models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.models.AsReadOnly();

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name)
       => this.models.FirstOrDefault(m => m.Name == name);
        public bool Remove(IEgg model)
        => this.models.Remove(model);
    }
}
