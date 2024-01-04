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
        private List<IRobot> robots;
        public RobotRepository()
        {
            this.robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            this.robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
       => this.robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));

        public IReadOnlyCollection<IRobot> Models()
        => this.robots.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            IRobot robot = this.robots.FirstOrDefault(r => r.GetType().Name == typeName);
            if(robot!=null)
            {
                this.robots.Remove(robot);
                return true;

            }
            return false;
        }
    }
}
