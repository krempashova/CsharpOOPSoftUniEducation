using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;
        public RobotRepository()
        {
            this.models = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            this.models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return this.models.FirstOrDefault(m => m.InterfaceStandards.Any(m => m == interfaceStandard));
        }
        public IReadOnlyCollection<IRobot> Models() => this.models.AsReadOnly();


        public bool RemoveByName(string typeName)
        {
            var modeltoRemoved = this.models.FirstOrDefault(m => m.GetType().Name == typeName);
            return this.models.Remove(modeltoRemoved);
        }

    }
}

