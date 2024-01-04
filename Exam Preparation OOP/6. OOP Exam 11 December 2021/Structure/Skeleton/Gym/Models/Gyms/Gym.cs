using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();

        }
        public string Name
        {
            get { return name; }
             private set 
            
            { 
                
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                
                name = value; 
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.CalculateWeight();

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
           
            if(this.athletes.Count==Capacity)
            {
                throw  new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }



           this.athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        => this.athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
        {

            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var athleteNames = new List<string>();
            foreach (var athlete in this.athletes)
            {
                athleteNames.Add(athlete.FullName);
            }
               
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {(athletes.Count == 0 ? "No athletes" : string.Join(", ", athleteNames))}");
            sb.AppendLine($"Equipment total count: {this.equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }

       
        private double CalculateWeight()
        {   
            double result = 0;
            foreach (var item in this.equipment)
            {
                 result+= item.Weight;
            }
            return result;
        }
    }
}
