using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        private List<IFormulaOneCar> models;
        public IReadOnlyCollection<IFormulaOneCar> Models => this.models;

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        => this.models.FirstOrDefault(m => m.Model == name);

        public bool Remove(IFormulaOneCar model)
        => this.models.Remove(model);
    }
}
