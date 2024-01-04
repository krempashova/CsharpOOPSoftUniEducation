using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        public DelicacyRepository()
        {
            this.availabledelicaties = new List<IDelicacy>();
        }
        private readonly List<IDelicacy> availabledelicaties;
        public IReadOnlyCollection<IDelicacy> Models => this.availabledelicaties; 

        public void AddModel(IDelicacy model)
        {
            this.availabledelicaties.Add(model);
        }
    }
}
