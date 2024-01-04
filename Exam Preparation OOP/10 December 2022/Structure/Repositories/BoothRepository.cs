using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        public BoothRepository()
        {
            this.booths = new List<IBooth>();
        }
        private readonly List<IBooth> booths;
        public IReadOnlyCollection<IBooth> Models => this.booths;

        public void AddModel(IBooth model)
        {
            this.booths.Add(model);
        }
    }
}
