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
           if(typeName!=nameof(DomesticAssistant) && typeName!=nameof(IndustrialAssistant))
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;
           if(typeName==nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
           else
            {
                robot = new IndustrialAssistant(model);
            }
            this.robots.AddNew(robot);
            return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName,model);


        }

        public string CreateSupplement(string typeName)
        {
            if(typeName!=nameof(SpecializedArm)&& typeName!=nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            ISupplement supplement;
            if(typeName==nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                supplement = new SpecializedArm();
            }

            this.supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);

        }
        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = this.supplements.Models().FirstOrDefault(m=>m.GetType().Name == supplementTypeName);

            var supplaimnatvalue = supplement.InterfaceStandard;
            var bymodel = this.robots.Models().Where(R => R.Model == model);
            var selectedrobots=bymodel.Where(r => r.InterfaceStandards.All(s => s != supplement.InterfaceStandard));

            var robotsforUpgrades = selectedrobots.FirstOrDefault();
            if(robotsforUpgrades!=null)
            {

                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            robotsforUpgrades.InstallSupplement(supplement);
            this.supplements.RemoveByName(supplementTypeName);
            return String.Format(OutputMessages.UpgradeSuccessful, model,supplementTypeName);

        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotLIST = this.robots.Models().Where(m => m.InterfaceStandards.Contains(intefaceStandard)).ToList();
            if(robotLIST.Count==0)
            {
                 return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            List<IRobot> selectedrobots = robotLIST.OrderByDescending(s => s.BatteryLevel).ToList();
            var SUMBATERY = selectedrobots.Sum(s => s.BatteryLevel);

            if(SUMBATERY< totalPowerNeeded)
            { var more = totalPowerNeeded - SUMBATERY;
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, more);
            }
            else
            {
                int robotsCounter = 0;
                foreach(var robot in selectedrobots) 
                { 
                if(robot.BatteryLevel>= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        robotsCounter++;
                        break;
                    }
              
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        robotsCounter++;
                    
                
                }
                return String.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsCounter);

            }

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            List<IRobot> robot = this.robots.Models().OrderByDescending(m => m.BatteryLevel).ThenBy(m => m.BatteryCapacity).ToList();
            foreach (var item in robot)
            {  
               sb.AppendLine( item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        { 


            
            List<IRobot> robot = this.robots.Models().Where(m=>m.BatteryLevel>m.BatteryCapacity/2).ToList();

            int count = 0;
            foreach (var item in robot)
            {
                item.Eating(minutes);
                count++;
            }
            return String.Format(OutputMessages.RobotsFed, count);
        }

       
    }
}
