using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {

        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            gyms = new List<IGym>();
            
        }
        public string AddGym(string gymType, string gymName)
        {
           
            if(gymType!=nameof(BoxingGym)&& gymType!=nameof(WeightliftingGym)) 
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym;
             if(gymType==nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
             else
            {
                gym = new WeightliftingGym(gymName);
            }
            this.gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);

        }

        public string AddEquipment(string equipmentType)
        {
           if(equipmentType!=nameof(BoxingGloves) && equipmentType!=nameof(Kettlebell))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            IEquipment equipment;
            if(equipmentType==nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }

            this.equipment.Add(equipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if(equipment==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment,equipmentType));
            }
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
       }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.Find(g => g.Name == gymName);
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if ((athleteType == "Boxer" && gym.GetType().Name == "WeightliftingGym") || (athleteType == "Weightlifter" && gym.GetType().Name == "BoxingGym"))
            {
                return OutputMessages.InappropriateGym;
            }

            IAthlete athlete;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            gym.AddAthlete(athlete);
            
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);

        }





        public string EquipmentWeight(string gymName)
        => $"The total weight of the equipment in the gym {gymName} is {(gyms.Find(g => g.Name == gymName).EquipmentWeight):f2} grams.";


        public string Report()
        {
            var sb = new StringBuilder();
            gyms.ForEach(g => sb.AppendLine(g.GymInfo()));
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.Find(g => g.Name == gymName);
            gym.Exercise();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Exercise athletes: {gym.Athletes.Count}.");

            return sb.ToString().TrimEnd();

        }
    }
}
