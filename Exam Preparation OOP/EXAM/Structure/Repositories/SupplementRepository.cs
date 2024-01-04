using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
       
        private List<ISupplement> models;
        public SupplementRepository()
        {
            this.models = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            this.models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        => this.models.FirstOrDefault(m => m.InterfaceStandard == interfaceStandard);

        public IReadOnlyCollection<ISupplement> Models()
       => this.models.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            var modeltoRemoved = this.models.FirstOrDefault(m => m.GetType().Name == typeName);
            return this.models.Remove(modeltoRemoved);
        }
        
    }
}
