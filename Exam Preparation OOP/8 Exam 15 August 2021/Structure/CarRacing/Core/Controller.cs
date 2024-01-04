using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository races;
        private IMap map;
        public Controller()
        {
            this.cars = new CarRepository();
            this.races = new RacerRepository();
            this.map = new Map();

        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {

            if (type != nameof(SuperCar) &&
                type != nameof(TunedCar))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            ICar car;
            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            this.cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);



        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type != nameof(StreetRacer) && type != nameof(ProfessionalRacer))
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            IRacer racer;
            if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                racer = new ProfessionalRacer(username, car);
            }

            this.races.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {

            IRacer racerOne = this.races.FindBy(racerOneUsername);
            IRacer racerTwo = this.races.FindBy(racerTwoUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in races.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))

            {

                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");

            }
            return sb.ToString().TrimEnd();
        }
         
    }

}       



