using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
           this.car = car;
        }

        public string Username
        {
            get { return username; }
           private  set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                username = value; 
            }
        }
        private string racingBehavior;

        public string RacingBehavior
        {
            get { return racingBehavior; }
           protected set 
            
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }


                racingBehavior = value; 
            }
        }

        private int drivingExperience;

        public int DrivingExperience
        {
            get { return drivingExperience; }
           protected  set 
            { 
                 if(value<0 || value>100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value; 
            }
        }

        private ICar car;

        public ICar Car
        {
            get { return  car; }
            private set 
            { 
                if(value==null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                this.car = value; 
            }
        }
        public virtual void Race()
        {

            car.Drive();


        }
        public bool IsAvailable()
        {
            if(car.FuelAvailable>=car.FuelConsumptionPerRace)
            {
                return true;
            }
            return false;
        }

       
    }
}
