using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            this.interfaseStandards = new List<int>();
            this.batteryLevel = batteryCapacity;
        }

        public string Model
        {
            get { return model; }
           private  set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                
                model = value;
            }
        }

        private int batteryCapacity;

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
          private   set 
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value; 
            }
        }
       
        private  readonly List<int> interfaseStandards;
        private int batteryLevel;

        public int BatteryLevel => this.batteryLevel;
        

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => this.interfaseStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            var energy = ConvertionCapacityIndex * minutes;
           this. batteryLevel += energy;
            if (BatteryLevel>BatteryCapacity)
            {
                BatteryCapacity = BatteryLevel;
            }
          


        }

        public bool ExecuteService(int consumedEnergy)
        {
           if(BatteryLevel>= consumedEnergy)
            {
                this.batteryLevel -= consumedEnergy;
                return true;
            }
           return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this.interfaseStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            this.batteryLevel -= supplement.BatteryUsage;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.Append($"--Supplements installed: ");
            if(interfaseStandards.Count==0)
            {
                sb.Append($"none");
            }
            else

            {
                sb.Append(String.Join(" ", interfaseStandards));
            }
           return sb.ToString().TrimEnd();
        }
    }
}
