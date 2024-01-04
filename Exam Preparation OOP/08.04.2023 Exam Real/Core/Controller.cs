using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        public Controller()
        {
            this.supplements = new SupplementRepository();
            this.robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
           if(typeName!="DomesticAssistant" && typeName!="IndustrialAssistant")
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot = null;
           if(typeName==nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);

            }
           else
            {
                robot = new IndustrialAssistant(model);
            }
            this.robots.AddNew(robot);
           
            
             
            return String.Format(OutputMessages.RobotCreatedSuccessfully,typeName,model);

        }

        public string CreateSupplement(string typeName)
        {
            if(typeName!=nameof(LaserRadar)&& typeName!=nameof(SpecializedArm))

            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            ISupplement supplement = null;
            if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();

            }
            else
            {
                supplement = new SpecializedArm();
            }

            this.supplements.AddNew(supplement);
            return String.Format(OutputMessages.SupplementCreatedSuccessfully,typeName);
        }
        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = this.supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            var selectedModels = this.robots.Models().Where(r => r.Model == model);
            var stillNotUpgraded = selectedModels.Where(r => r.InterfaceStandards.All(s => s != supplement.InterfaceStandard));
            var robotForUpgrade = stillNotUpgraded.FirstOrDefault();
            if (robotForUpgrade == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robotForUpgrade.InstallSupplement(supplement);
                this.supplements.RemoveByName(supplementTypeName);
                return String.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);





        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            int counter = 0;
            IRobot robot = null;
            List<IRobot> selectedrobots = this.robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).ToList();
            if(selectedrobots.Count==0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            List<IRobot>sortedrobots= selectedrobots.OrderByDescending(s=>s.BatteryLevel).ToList();
            int baterySum = sortedrobots.Sum(r => r.BatteryLevel);

            if(baterySum< totalPowerNeeded)
            {
                int availablepower = totalPowerNeeded - baterySum;
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, availablepower);
            }
            else if(baterySum>=totalPowerNeeded)
            {
                foreach (var item in sortedrobots)
                {
                    if(item.BatteryLevel>=totalPowerNeeded)
                    {
                        item.ExecuteService(totalPowerNeeded);
                        counter++;
                        break;
                    }
                    else if(item.BatteryLevel<totalPowerNeeded)
                    {
                       totalPowerNeeded-=item.BatteryLevel;
                        item.ExecuteService(item.BatteryLevel);
                        counter++;
                    }
                }

            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
        }
        public string RobotRecovery(string model, int minutes)
        {
            int counter = 0;
            foreach (var item in robots.Models().Where(r=>r.Model==model && r.BatteryLevel>=r.BatteryCapacity/2))
            {
                item.Eating(minutes);
                counter++;

            }

            return String.Format(OutputMessages.RobotsFed, counter);

        }

        public string Report()
        {
            StringBuilder sb
                = new StringBuilder();
            List<IRobot>sortedrobotrs=robots.Models().OrderByDescending(r=>r.BatteryLevel).ThenBy(r=>r.BatteryCapacity).ToList();
            foreach (var item in sortedrobotrs)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

      

       
    }
}
